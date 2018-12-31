using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using YoutubeClientManagerBeta.Video;

namespace YoutubeClientManagerBeta
{
    public sealed class YoutubeClient : IDisposable
    {
        #region GLOBAL_VARIABLE
        private HttpClient httpClient;
        #endregion

        #region CONSTRUCTOR
        public YoutubeClient()
        {
            httpClient = new HttpClient();
        }
        #endregion

        #region SEARCH
        private static bool ValidateVideoId(string videoId)
        {
            bool isValid = false;

            if (videoId.Length == 11)
            {
                isValid = (!Regex.IsMatch(videoId, @"[^0-9a-zA-Z_\-]"));
            }

            return isValid;
        }

        private bool TryParseVideoId(string videoUrl, out string videoId)
        {
            videoId = string.Empty;

            string regularMatch = Regex.Match(videoUrl, @"youtube\..+?/watch.*?v=(.*?)(?:&|/|$)").Groups[1].Value;
            if ((regularMatch != string.Empty) && (ValidateVideoId(regularMatch)))
            {
                videoId = regularMatch;
                return true;
            }

            string shortMatch = Regex.Match(videoUrl, @"youtu\.be/(.*?)(?:\?|&|/|$)").Groups[1].Value;
            if ((shortMatch != string.Empty) && (ValidateVideoId(shortMatch)))
            {
                videoId = shortMatch;
                return true;
            }

            string embedMatch = Regex.Match(videoUrl, @"youtube\..+?/embed/(.*?)(?:\?|&|/|$)").Groups[1].Value;
            if ((embedMatch != string.Empty) && (ValidateVideoId(embedMatch)))
            {
                videoId = embedMatch;
                return true;
            }

            return false;
        }

        public async Task<string[]> SearchVideoIdAsync(string searchQuery, int maxResults)
        {
            searchQuery = Utilities.ValidateGenericField(searchQuery, nameof(searchQuery));

            if (maxResults <= 0)
            {
                throw (new ArgumentOutOfRangeException(nameof(maxResults)));
            }

            List<string> videoIdList = new List<string>();

            if (TryParseVideoId(searchQuery, out string videoId))
            {
                if ((await httpClient.GetStringAsync(searchQuery).ConfigureAwait(false)).Contains("ypc-checkout-button"))
                {
                    throw (new Exception("Il video cercato è a pagamento, pertanto non può essere elaborato."));
                }

                videoIdList.Add(videoId);
            }
            else
            {
                string[] videoIds = (await httpClient.GetStringAsync(("https://www.youtube.com/results?search_query=" + searchQuery)).
                    ConfigureAwait(false)).Split(new string[] { "href=\"/watch?v=" }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 1; i != videoIds.Length; i++)
                {
                    videoId = videoIds[i].Substring(0, 11);

                    if (!videoIdList.Contains(videoId))
                    {
                        videoIdList.Add(videoId);
                    }
                    else if (videoIds[i].Contains("ypc-checkout-button"))
                    {
                        videoIdList.Remove(videoId);
                    }
                }

                if (videoIdList.Count > maxResults)
                {
                    videoIdList.RemoveRange(maxResults, (videoIdList.Count - maxResults));
                }
            }

            return videoIdList.ToArray();
        }
        #endregion

        #region VIDEO
        private async Task<string> GetVideoInfoRawAsync(string videoId, string el)
        {
            string requestUri = ($"https://www.youtube.com/get_video_info?video_id={videoId}&el={el}");

            return (await httpClient.GetStringAsync(requestUri).ConfigureAwait(false));
        }

        private async Task<Dictionary<string, string>> GetVideoInfoADictonaryAsync(string videoId)
        {
            Dictionary<string, string> dictionary = Utilities.SplitUrlQuery((await GetVideoInfoRawAsync(videoId, "embedded").ConfigureAwait(false)));
            dictionary.Add("verified", "False");

            if ((dictionary.ContainsKey("errorcode")) && (dictionary["errorcode"] == "150"))
            {
                dictionary = Utilities.SplitUrlQuery((await GetVideoInfoRawAsync(videoId, "detailpage").ConfigureAwait(false)));
                dictionary.Add("verified", "True");
            }

            return dictionary;
        }

        private string GetDescription(string watchPage)
        {
            watchPage = Utilities.ExtractValue(watchPage, "<p id=\"eow-description\" class=\"\" >", "</p>");
            watchPage = watchPage.Replace("<br />", Environment.NewLine);

            string[] descriptions = watchPage.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

            for (int i = 0; i != descriptions.Length; i++)
            {
                descriptions[i] = (string.IsNullOrWhiteSpace(descriptions[i]) ? Environment.NewLine : descriptions[i]);

                // Implementare multipli per frase
                if (descriptions[i].Contains("<a href="))
                {
                    descriptions[i] = (Utilities.ExtractValue(descriptions[i], "", "<") + Utilities.ExtractValue(descriptions[i], ">", "</a>"));

                    if (i != (descriptions.Length - 1))
                    {
                        descriptions[i] += Environment.NewLine;
                    }
                }
            }

            return (string.Concat(descriptions));
        }

        private long GetStatisticsCount(string countValueRaw)
        {
            long countValue = 0;

            if (countValueRaw.Contains("yt-uix-button-content\">"))
            {
                countValue = long.Parse(Utilities.ExtractValue(countValueRaw, "yt-uix-button-content\">", "</span>").Replace(".", ""));
            }

            return countValue;
        }

        private Statistics GetStatistics(string watchPage, string playerResponseRaw, string averageRatingRaw)
        {
            Statistics statistics = new Statistics
            {
                ViewCount = long.Parse(Utilities.ExtractValue(playerResponseRaw, "viewCount\":\"", "\"")),
                LikeCount = GetStatisticsCount(Utilities.ExtractValue(watchPage, "like-button-renderer-like-button", "</button>")),
                DislikeCount = GetStatisticsCount(Utilities.ExtractValue(watchPage, "like-button-renderer-dislike-button", "</button>")),
                AverageRating = Math.Round(double.Parse(averageRatingRaw.Replace(".", ",")), 1)
            };

            return statistics;
        }

        private StreamFormat GetStreamFormats(Dictionary<string, string> dictonary)
        {
            StreamFormat streamFormat = new StreamFormat();

            if (dictonary.ContainsKey("adaptive_fmts"))
            {
                streamFormat.IsAdaptive = true;
                streamFormat.Url = dictonary["adaptive_fmts"];
            }
            else
            {
                streamFormat.Url = dictonary["dashmpd"];
            }

            return streamFormat;
        }

        public async Task<VideoInfo> GetVideoInfoAsync(string videoId)
        {
            videoId = Utilities.ValidateGenericField(videoId, nameof(videoId));

            if (!ValidateVideoId(videoId))
            {
                throw (new ArgumentException(nameof(videoId)));
            }

            Dictionary<string, string> videoInfoDictonary = (await GetVideoInfoADictonaryAsync(videoId).ConfigureAwait(false));
            string videoWatchPageRaw = (await httpClient.GetStringAsync($"https://www.youtube.com/watch?v={videoId}").ConfigureAwait(false));

            VideoInfo videoInfo = new VideoInfo(videoId)
            {
                Author = videoInfoDictonary["author"],
                Title = videoInfoDictonary["title"],
                Description = GetDescription(videoWatchPageRaw),
                Duration = TimeSpan.FromSeconds(double.Parse(videoInfoDictonary["length_seconds"])),
                UploadDate = DateTime.Parse(Utilities.ExtractValue(videoWatchPageRaw, "<meta itemprop=\"datePublished\" content=\"", "\">")),
                Statistics = GetStatistics(videoWatchPageRaw, videoInfoDictonary["player_response"], videoInfoDictonary["avg_rating"]),
                Thumbnails = new ThumbnailSet(videoId),
                Keywords = Utilities.ExtractValue(videoInfoDictonary["player_response"], "keywords\":[", "]").Replace("\"", "").Split(','),
                IsVerified = bool.Parse(videoInfoDictonary["verified"]),
                StreamFormat = GetStreamFormats(videoInfoDictonary)
            };

            return videoInfo;
        }
        #endregion

        #region DISPOSE
        private bool disposedValue = false;

        public void Dispose()
        {
            if (!disposedValue)
            {
                disposedValue = true;

                httpClient.Dispose();
            }
        }
        #endregion
    }
}
