using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using YoutubeClientManagerBeta.Audio;
using YoutubeClientManagerBeta.Video;

namespace YoutubeAudioDownloaderBeta.Main.Search
{
    public partial class SearchUserControl : UserControl
    {
        #region GLOBAL_VARIABLES
        public static Action<VideoInfo, AudioInfo, Action> ActionToPerform { private get; set; }

        private AudioInfo audioInfo;

        private VideoInfo videoInfo;
        #endregion

        #region USERCONTROL_EVENTS
        public SearchUserControl(VideoInfo videoInfo)
        {
            InitializeComponent();

            DoubleBuffered = true;

            audioInfo = null;
            this.videoInfo = videoInfo;
            buttonDownload.Enabled = false;

            SearchUserControl_LoadAsync(this, new EventArgs());
        }

        private async void SearchUserControl_LoadAsync(object sender, EventArgs e)
        {
            webBrowserVideo.Navigate(videoInfo.GetEmbedUrl());

            labelAuthor.Text = ("Autore: " + videoInfo.Author);
            labelTitle.Text = ("Titolo: " + videoInfo.Title);
            labelDuration.Text = ("Durata: " + videoInfo.Duration.ToString());
            labelUploadDate.Text = ("Data Caricamento: " + videoInfo.UploadDate.ToString("dd/MM/yyyy"));
            labelAverageRating.Text = ("Valutazione Media: " + videoInfo.Statistics.AverageRating + "/5");

            labelContainerEncoding.Text = "Container/Encoding: Attendere...";
            labelBitrate.Text = "Bitrate: Attendere...";
            labelSize.Text = "Dimensione: Attendere...";

            try
            {
                audioInfo = await videoInfo.GetAudioInfoAsync();

                labelContainerEncoding.Text = ("Container/Encoding: " + audioInfo.Container + "/" + audioInfo.Encoding);
                labelBitrate.Text = ("Bitrate: " + Math.Round((audioInfo.Bitrate / 1000f), MidpointRounding.ToEven) + " Kb/s");
                labelSize.Text = ("Dimensione: " + Math.Round(((audioInfo.Size / 1024f) / 1024f), 2).ToString() + " Mb");

                buttonDownload.Enabled = true;
            }
            catch (Exception ex)
            {
                labelContainerEncoding.Text = "Container/Encoding: Errore ricezione informazioni.";
                labelBitrate.Text = "Bitrate: Errore ricezione informazioni.";
                labelSize.Text = "Dimensione: Errore ricezione informazioni.";
            }
        }
        #endregion

        #region LINKLABEL_EVENT
        private void linkLabelShowOther_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            using (InformationForm informationForm = new InformationForm(videoInfo))
            {
                informationForm.ShowDialog();
            }
        }
        #endregion

        #region WEBBROWSER_EVENT
        private void webBrowserVideo_NewWindow(object sender, CancelEventArgs e)
        {
            e.Cancel = true;

            Process.Start(videoInfo.GetRegularUrl()).Dispose();
        }
        #endregion

        #region BUTTON_EVENT
        private void buttonDownload_Click(object sender, EventArgs e)
        {
            ActionToPerform?.Invoke(videoInfo, audioInfo, EnableDownloadButton);

            buttonDownload.Enabled = false;
        }
        #endregion

        #region RESET
        private void EnableDownloadButton()
        {
            buttonDownload.Enabled = true;
        }
        #endregion
    }
}
