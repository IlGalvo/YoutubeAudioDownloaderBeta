using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using YoutubeClientManagerBeta.Audio.Itag;

namespace YoutubeClientManagerBeta.Audio
{
    public sealed class AudioInfo
    {
        #region GLOBAL_VARIABLES
        private AudioInfoStatus audioInfoStatus;

        private int itag;
        internal int Itag { get { return itag; } set { SetItag(value); } }
        public AudioContainer Container { get; private set; }
        public AudioEncoding Encoding { get; private set; }
        public long Size { get; internal set; }
        public long Bitrate { get; internal set; }
        internal string Url { get; set; }

        public event DownloadProgressEventHandler DownloadProgress;
        public event DownloadFinishedEventHandler DownloadFinished;
        #endregion

        #region CONSTRUCTOR
        internal AudioInfo()
        {
            audioInfoStatus = null;

            Itag = 0;
            Size = 0;
            Bitrate = 0;
            Url = string.Empty;
        }
        #endregion

        #region ITAG
        private void SetItag(int itag)
        {
            this.itag = itag;

            Container = ItagInfo.GetContainer(itag);
            Encoding = ItagInfo.GetEncoding(itag);
        }
        #endregion

        #region EXTENSIONS
        public string GetContainerFileExtension()
        {
            return ("." + Container.ToString().ToLower());
        }

        public string GetEncodingFileExtension()
        {
            return ("." + Encoding.ToString().ToLower());
        }
        #endregion

        #region DOWNLOAD
        public async void DownloadAsync(string filePath, object userToken)
        {
            filePath = Utilities.ValidateGenericField(filePath, nameof(filePath));

            try
            {
                audioInfoStatus = new AudioInfoStatus();

                using (HttpClient httpClient = new HttpClient())
                using (FileStream fileStream = File.Create(filePath))
                {
                    long totalBytesCopied = 0;

                    if (!Url.Contains("ratebypass=yes"))
                    {
                        const long SegmentSize = 9_898_989;

                        for (int i = 0; i < ((int)Math.Ceiling(((1.0 * Size) / SegmentSize))); i++)
                        {
                            using (HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, Url))
                            {
                                httpRequestMessage.Headers.Range = new RangeHeaderValue((SegmentSize * i), (((i + 1) * (SegmentSize - 1))));
                                HttpCompletionOption httpCompletionOption = HttpCompletionOption.ResponseHeadersRead;

                                using (HttpResponseMessage httpResponseMessage = (await httpClient.SendAsync(httpRequestMessage,
                                    httpCompletionOption, audioInfoStatus.Token).ConfigureAwait(false)).EnsureSuccessStatusCode())
                                using (Stream stream = (await httpResponseMessage.Content.ReadAsStreamAsync().ConfigureAwait(false)))
                                {
                                    int bytesCopied = 0;

                                    do
                                    {
                                        byte[] buffer = new byte[81920];

                                        totalBytesCopied += bytesCopied = (await stream.ReadAsync(buffer, 0, buffer.Length,
                                            audioInfoStatus.Token).ConfigureAwait(false));
                                        await fileStream.WriteAsync(buffer, 0, bytesCopied, audioInfoStatus.Token).ConfigureAwait(false);

                                        DownloadProgress?.Invoke(this, new DownloadProgressEventArgs(totalBytesCopied, Size, userToken));
                                    } while (bytesCopied > 0);
                                }
                            }
                        }
                    }
                    else
                    {
                        using (Stream stream = (await httpClient.GetStreamAsync(Url).ConfigureAwait(false)))
                        {
                            int bytesCopied = 0;

                            do
                            {
                                byte[] buffer = new byte[81920];

                                totalBytesCopied += bytesCopied = (await stream.ReadAsync(buffer, 0, buffer.Length,
                                    audioInfoStatus.Token).ConfigureAwait(false));
                                await fileStream.WriteAsync(buffer, 0, bytesCopied, audioInfoStatus.Token).ConfigureAwait(false);

                                DownloadProgress?.Invoke(this, new DownloadProgressEventArgs(totalBytesCopied, Size, userToken));
                            } while (bytesCopied > 0);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                if (!(exception is TaskCanceledException))
                {
                    audioInfoStatus.Error = exception;
                }
            }
            finally
            {
                bool cancelled = audioInfoStatus.Token.IsCancellationRequested;
                DownloadFinished?.Invoke(this, new AsyncCompletedEventArgs(audioInfoStatus.Error, cancelled, userToken));

                audioInfoStatus = null;
            }
        }

        public void CancelAsync()
        {
            if (audioInfoStatus != null)
            {
                audioInfoStatus.Token = new CancellationToken(true);
            }
        }
        #endregion
    }
}