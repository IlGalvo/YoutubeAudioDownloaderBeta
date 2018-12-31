using System;
using System.Diagnostics;
using System.Windows.Forms;
using YoutubeClientManagerBeta.Video;

namespace YoutubeAudioDownloaderBeta.Main.Search
{
    public partial class InformationForm : Form
    {
        #region GLOBAL_VARIABLE
        private VideoInfo videoInfo;
        #endregion

        #region FORM_EVENTS
        public InformationForm(VideoInfo videoInfo)
        {
            InitializeComponent();

            this.videoInfo = videoInfo;
        }

        private void InformationForm_Load(object sender, EventArgs e)
        {
            richTextBoxDescription.Text = videoInfo.Description;

            labelLikes.Text += videoInfo.Statistics.LikeCount.ToString();
            labelDislikes.Text += videoInfo.Statistics.DislikeCount.ToString();

            labelViews.Text += videoInfo.Statistics.ViewCount.ToString();
            labelVerified.Text += (videoInfo.IsVerified ? "Si" : "No");

            linkLabelVideo.Text = videoInfo.GetRegularUrl();
        }
        #endregion

        #region RICHTEXTBOX_EVENT
        private void richTextBoxDescription_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText).Dispose();
        }
        #endregion

        #region LINKLABEL_EVENT
        private void linkLabelVideo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(linkLabelVideo.Text).Dispose();
        }
        #endregion
    }
}
