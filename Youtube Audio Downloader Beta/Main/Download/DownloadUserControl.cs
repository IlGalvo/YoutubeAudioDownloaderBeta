using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using YoutubeClientManagerBeta.Audio;
using YoutubeClientManagerBeta.Converter;
using YoutubeClientManagerBeta.Video;

namespace YoutubeAudioDownloaderBeta.Main.Download
{
    public partial class DownloadUserControl : UserControl
    {
        #region GLOBAL_VARIABLES
        public bool IsRunning { get; private set; }

        private ConverterMp3 converterMp3;

        private AudioInfo audioInfo;
        private string downloadPath;
        private Action actionToPerform;

        private object lockObject;
        #endregion

        #region USERCONTROL_EVENTS
        public DownloadUserControl(VideoInfo videoInfo, AudioInfo audioInfo, string downloadDirectoryPath, Action actionToPerform)
        {
            InitializeComponent();

            DoubleBuffered = true;

            converterMp3 = new ConverterMp3();

            this.audioInfo = audioInfo;
            this.actionToPerform = actionToPerform;

            lockObject = new object();

            downloadPath = (string.Join("-", videoInfo.Title.Split(Path.GetInvalidFileNameChars())) + audioInfo.GetContainerFileExtension());
            downloadPath = Path.Combine(downloadDirectoryPath, downloadPath);

            IsRunning = false;

            Startup(videoInfo);
        }

        private void Startup(VideoInfo videoInfo)
        {
            converterMp3.ConvertionProgress += ConverterMp3_ConvertionProgress;
            converterMp3.ConvertionFinished += ConverterMp3_ConvertionFinished;

            audioInfo.DownloadProgress += AudioInfo_DownloadProgress;
            audioInfo.DownloadFinished += AudioInfo_DownloadFinished;

            pictureBoxImage.LoadAsync(videoInfo.Thumbnails.HighResolutionUrl);

            labelTitle.Text = ("Titolo: " + videoInfo.Title);
            labelBitrateSize.Text = ("Bitrate: 320kb/s     |     " +
                "Dimensione: " + (((audioInfo.Size * 2.5) / 1024f) / 1024f).ToString("00.00") + " Mb~");
            labelInformation.Text = "Pronto";

            buttonDownloadCancel_Click(this, new EventArgs());
        }
        #endregion

        #region BUTTONDOWNLOADCANCEL_EVENT
        private void buttonDownloadCancel_Click(object sender, EventArgs e)
        {
            if (buttonDownloadCancel.Text == "Scarica")
            {
                audioInfo.DownloadAsync(downloadPath, Path.ChangeExtension(downloadPath, ".mp3"));

                SetLabelText("Download in corso...");
                SetButtonDownloadCancelText("Annulla");
                EnableButtonRemove(false);

                IsRunning = true;
            }
            else
            {
                audioInfo.CancelAsync();
                converterMp3.CancelAsync();
            }
        }
        #endregion

        #region BUTTONDOWNLOADCANCEL_STATUS
        private void SetButtonDownloadCancelText(string text)
        {
            if (buttonDownloadCancel.InvokeRequired)
            {
                buttonDownloadCancel.BeginInvoke((MethodInvoker)delegate ()
                {
                    SetButtonDownloadCancelText(text);
                });
            }
            else
            {
                buttonDownloadCancel.Text = text;
            }
        }
        #endregion

        #region DOWNLOAD_EVENTS
        private void AudioInfo_DownloadProgress(object sender, DownloadProgressEventArgs e)
        {
            SetProgressBarPercentage(e.ProgressPercentage);
        }

        private void AudioInfo_DownloadFinished(object sender, AsyncCompletedEventArgs e)
        {
            ManageAsyncCompleteEventArgs(e, true);
        }
        #endregion

        #region CONVERTER_EVENTS
        private void ConverterMp3_ConvertionProgress(object sender, ConversionProgressEventArgs e)
        {
            SetProgressBarPercentage(e.ProgressPercentage);
        }

        private void ConverterMp3_ConvertionFinished(object sender, AsyncCompletedEventArgs e)
        {
            ManageAsyncCompleteEventArgs(e, false);
        }
        #endregion

        #region ASYNC_MANAGERS
        private void ManageAsyncCompleteEventArgs(AsyncCompletedEventArgs asyncCompletedEventArgs, bool isDownload)
        {
            string fileName = (isDownload ? downloadPath : asyncCompletedEventArgs.UserState.ToString());

            if (asyncCompletedEventArgs.Cancelled)
            {
                ManageResultOperations(fileName, "Operazione annullata.", 0);
            }
            else if (asyncCompletedEventArgs.Error != null)
            {
                ManageResultOperations(fileName, ("Errore: " + asyncCompletedEventArgs.Error.Message + "."), 0);
            }
            else if (isDownload)
            {
                converterMp3.ConvertToMp3Async(fileName, asyncCompletedEventArgs.UserState.ToString(), asyncCompletedEventArgs.UserState);

                SetLabelText("Conversione in corso...");
            }
            else
            {
                ManageResultOperations(string.Empty, "Completato.", 100);
            }

            if (!isDownload)
            {
                File.Delete(downloadPath);
            }

            lock (lockObject)
            {
                Monitor.Pulse(lockObject);
            }
        }

        private void ManageResultOperations(string fileName, string message, int percentage)
        {
            if (fileName != string.Empty)
            {
                File.Delete(fileName);
            }

            SetLabelText(message);
            SetButtonDownloadCancelText("Scarica");

            EnableButtonRemove(true);
            SetProgressBarPercentage(percentage);

            IsRunning = false;
        }
        #endregion

        #region PROGRESSBAR_STATUS
        private void SetProgressBarPercentage(int percentage)
        {
            if (coloredProgressBarPercentage.InvokeRequired)
            {
                coloredProgressBarPercentage.BeginInvoke((MethodInvoker)delegate ()
                {
                    SetProgressBarPercentage(percentage);
                });
            }
            else
            {
                coloredProgressBarPercentage.Value = percentage;
            }
        }
        #endregion

        #region LABEL_STATUS
        private void SetLabelText(string text)
        {
            if (labelInformation.InvokeRequired)
            {
                labelInformation.BeginInvoke((MethodInvoker)delegate ()
                {
                    SetLabelText(text);
                });
            }
            else
            {
                labelInformation.Text = text;
            }
        }
        #endregion

        #region BUTTONREMOVE_EVENT
        private void buttonRemove_Click(object sender, EventArgs e)
        {
            string fileName = Path.ChangeExtension(downloadPath, ".mp3");

            if (File.Exists(fileName))
            {
                string text = "Vuoi eliminare anche il file?";

                if (MessageBox.Show(text, "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    File.Delete(fileName);
                }
            }

            Parent.Controls.Remove(this);
        }
        #endregion

        #region BUTTONREMOVE_STATUS
        private void EnableButtonRemove(bool enable)
        {
            if (buttonRemove.InvokeRequired)
            {
                buttonRemove.BeginInvoke((MethodInvoker)delegate ()
                {
                    EnableButtonRemove(enable);
                });
            }
            else
            {
                buttonRemove.Enabled = enable;
            }
        }
        #endregion
    }
}
