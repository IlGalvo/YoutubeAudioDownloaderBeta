using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YoutubeClientManagerBeta.Audio;
using YoutubeClientManagerBeta.Video.Cipher;

namespace YoutubeClientManagerBeta.Video
{
    public sealed class VideoInfo
    {
        #region GLOBAL_VARIABLES
        public string Id { get; internal set; }
        public string Author { get; internal set; }
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public TimeSpan Duration { get; internal set; }
        public DateTime UploadDate { get; internal set; }
        public Statistics Statistics { get; internal set; }
        public ThumbnailSet Thumbnails { get; internal set; }
        public string[] Keywords { get; internal set; }
        public bool IsVerified { get; internal set; }
        internal StreamFormat StreamFormat { get; set; }
        #endregion

        #region CONSTRUCTOR
        internal VideoInfo(string id)
        {
            Id = id;
            Author = string.Empty;
            Title = string.Empty;
            Description = string.Empty;
            Duration = TimeSpan.Zero;
            UploadDate = DateTime.MinValue;
            Statistics = new Statistics();
            Thumbnails = new ThumbnailSet(id);
            Keywords = new string[] { };
            IsVerified = false;
            StreamFormat = new StreamFormat();
        }
        #endregion

        #region URLS
        public string GetRegularUrl()
        {
            return ($"https://www.youtube.com/watch?v={Id}");
        }

        public string GetShortUrl()
        {
            return ($"https://youtu.be/{Id}");
        }

        public string GetEmbedUrl()
        {
            return ($"https://www.youtube.com/embed/{Id}");
        }
        #endregion

        #region AUDIO
        private async Task<string> GetPlayerSourceRawAsync(string videoId)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string requestUri = (await httpClient.GetStringAsync($"https://www.youtube.com/embed/{videoId}").ConfigureAwait(false));

                requestUri = Utilities.ExtractValue(requestUri, "yt.setConfig({'PLAYER_CONFIG': ", "});");
                requestUri = Utilities.ExtractValue(requestUri, "js\":\"", "\"").Replace("\\", "");

                return (await httpClient.GetStringAsync(("https://www.youtube.com" + requestUri)).ConfigureAwait(false));
            }
        }

        private PlayerSource GetPlayerSource(string sourceRaw)
        {
            // Find the name of the function that handles deciphering
            var entryPoint = Regex.Match(sourceRaw, @"\bc\s*&&\s*d\.set\([^,]+\s*,\s*\([^)]*\)\s*\(\s*([a-zA-Z0-9$]+)\(").Groups[1].Value;

            if (string.IsNullOrWhiteSpace(entryPoint))
                throw new Exception();//new ParseException("Could not find the entry function for signature deciphering.");

            // Find the body of the function
            var entryPointPattern = (@"(?!h\.)" + Regex.Escape(entryPoint) + @"=function\(\w+\)\{(.*?)\}");
            var entryPointBody = Regex.Match(sourceRaw, entryPointPattern, RegexOptions.Singleline).Groups[1].Value;

            if (string.IsNullOrWhiteSpace(entryPointBody))
                throw new Exception();//new ParseException("Could not find the signature decipherer function body.");

            var entryPointLines = entryPointBody.Split(';');

            // Identify cipher functions
            string reverseFuncName = null;
            string sliceFuncName = null;
            string charSwapFuncName = null;
            var operations = new List<ICipherOperation>();

            // Analyze the function body to determine the names of cipher functions
            foreach (var line in entryPointLines)
            {
                // Break when all functions are found
                if (!string.IsNullOrWhiteSpace(reverseFuncName) &&
                    !string.IsNullOrWhiteSpace(sliceFuncName) &&
                    !string.IsNullOrWhiteSpace(charSwapFuncName))
                    break;

                // Get the function called on this line
                var calledFuncName = Regex.Match(line, @"\w+(?:.|\[)(\""?\w+(?:\"")?)\]?\(").Groups[1].Value;
                if (string.IsNullOrWhiteSpace(calledFuncName))
                    continue;

                // Find cipher function names
                if (Regex.IsMatch(sourceRaw, $@"{Regex.Escape(calledFuncName)}:\bfunction\b\(\w+\)"))
                {
                    reverseFuncName = calledFuncName;
                }
                else if (Regex.IsMatch(sourceRaw, $@"{Regex.Escape(calledFuncName)}:\bfunction\b\([a],b\).(\breturn\b)?.?\w+\."))
                {
                    sliceFuncName = calledFuncName;
                }
                else if (Regex.IsMatch(sourceRaw, $@"{Regex.Escape(calledFuncName)}:\bfunction\b\(\w+\,\w\).\bvar\b.\bc=a\b"))
                {
                    charSwapFuncName = calledFuncName;
                }
            }

            // Analyze the function body again to determine the operation set and order
            foreach (var line in entryPointLines)
            {
                // Get the function called on this line
                var calledFuncName = Regex.Match(line, @"\w+(?:.|\[)(\""?\w+(?:\"")?)\]?\(").Groups[1].Value;
                if (string.IsNullOrWhiteSpace(calledFuncName))
                    continue;

                // Swap operation
                if (calledFuncName == charSwapFuncName)
                {
                    var index = int.Parse(Regex.Match(line, @"\(\w+,(\d+)\)").Groups[1].Value);
                    operations.Add(new SwapCipherOperation(index));
                }
                // Slice operation
                else if (calledFuncName == sliceFuncName)
                {
                    var index = int.Parse(Regex.Match(line, @"\(\w+,(\d+)\)").Groups[1].Value);
                    operations.Add(new SliceCipherOperation(index));
                }
                // Reverse operation
                else if (calledFuncName == reverseFuncName)
                {
                    operations.Add(new ReverseCipherOperation());
                }
            }

            return (new PlayerSource(operations));
        }

        private string GetUrl(string url, string signature, PlayerSource playerSource, bool isAdaptive = true)
        {
            if (signature != string.Empty)
            {
                string signatureName = nameof(signature);
                signature = playerSource.Decipher(signature);

                Match existingMatch = Regex.Match(url, $@"[?&]({Regex.Escape(signatureName)}=?.*?)(?:&|/|$)");

                if (existingMatch.Success)
                {
                    Group group = existingMatch.Groups[1];

                    url = (url.Remove(group.Index, group.Length).Insert(group.Index, $"{signatureName}={signature}"));
                }
                else if (isAdaptive)
                {
                    char separator = ((url.IndexOf('?') >= 0) ? '&' : '?');

                    url = (url + separator + signatureName + '=' + signature);
                }
                else
                {
                    url = (url + '/' + signatureName + '/' + signature);
                }
            }

            return url;
        }

        public async Task<AudioInfo> GetAudioInfoAsync()
        {
            AudioInfo audioInfo = new AudioInfo();

            string playerSourceRaw = (await GetPlayerSourceRawAsync(Id).ConfigureAwait(false));
            PlayerSource playerSource = GetPlayerSource(playerSourceRaw);

            if (StreamFormat.IsAdaptive)
            {
                foreach (string streamEncoded in StreamFormat.Url.Split(','))
                {
                    Dictionary<string, string> dictionary = Utilities.SplitUrlQuery(streamEncoded);

                    if (dictionary["type"].Contains("audio"))
                    {
                        AudioInfo tmpAudioInfo = new AudioInfo
                        {
                            Itag = int.Parse(dictionary["itag"]),
                            Size = long.Parse(dictionary["clen"]),
                            Bitrate = long.Parse(dictionary["bitrate"]),
                            Url = GetUrl(dictionary["url"], (dictionary.ContainsKey("s") ? dictionary["s"] : string.Empty), playerSource)
                        };

                        if (audioInfo.Bitrate < tmpAudioInfo.Bitrate)
                        {
                            audioInfo = tmpAudioInfo;
                        }
                    }
                }
            }
            else
            {
                using (HttpClient httpClient = new HttpClient())
                {
                    string signature = Regex.Match(StreamFormat.Url, @"/s/(.*?)(?:/|$)").Groups[1].Value;
                    string dashManifestUrl = GetUrl(StreamFormat.Url, signature, playerSource, false);

                    string dashManifest = (await httpClient.GetStringAsync(dashManifestUrl).ConfigureAwait(false));
                    string[] dashManifests = dashManifest.Split(new string[] { "<Representation " }, StringSplitOptions.RemoveEmptyEntries);

                    for (int i = 1; i != dashManifests.Length; i++)
                    {
                        if (dashManifests[i].Contains("AudioChannelConfiguration"))
                        {
                            AudioInfo tmpAudioInfo = new AudioInfo
                            {
                                Itag = int.Parse(Utilities.ExtractValue(dashManifests[i], "id=\"", "\"")),
                                Size = long.Parse(Utilities.ExtractValue(dashManifests[i], "clen/", "/")),
                                Bitrate = long.Parse(Utilities.ExtractValue(dashManifests[i], "bandwidth=\"", "\"")),
                                Url = Utilities.ExtractValue(dashManifests[i], "<BaseURL>", "</BaseURL>")
                            };

                            if (audioInfo.Bitrate < tmpAudioInfo.Bitrate)
                            {
                                audioInfo = tmpAudioInfo;
                            }
                        }
                    }
                }
            }

            return audioInfo;
        }
        #endregion
    }
}