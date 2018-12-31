using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using YoutubeAudioDownloaderBeta.Main.Download;
using YoutubeAudioDownloaderBeta.Main.Search;
using YoutubeClientManagerBeta;
using YoutubeClientManagerBeta.Audio;
using YoutubeClientManagerBeta.Video;

namespace YoutubeAudioDownloaderBeta.Main
{
    public partial class MainForm : Form
    {
        #region GLOBAL_VARIABLES      
        private AnimationManager animationManager;
        private SettingsManager settingsManager;

        private VideoInfo[] videoInfos;
        #endregion

        #region FORM_EVENTS
        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;

            animationManager = new AnimationManager(((panelMenu.Width - buttonMenu.Width) - panelMenu.Left));
            animationManager.AddSizeAnimationControls(true, panelMenu, buttonMenuSearch, buttonMenuDownload);
            animationManager.AddLocationAnimationControls(labelInformation, buttonShowAll, buttonResetAll);
            animationManager.AddAllAnimationControls(textBoxPath, textBoxSearch, flowLayoutPanelSearch, flowLayoutPanelDownload);

            settingsManager = SettingsManager.CreateOrLoadSettings();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            SearchUserControl.ActionToPerform = AddToDownload;

            toggleButtonAutoDownload.ToggleState = settingsManager.AutoDownload;
            textBoxPath.Text = settingsManager.DownloadDirectory;
            numericUpDownSearch.Value = settingsManager.SearchResults;

            folderBrowserDialogPath.SelectedPath = textBoxPath.Text;

            buttonShowAll.Enabled = false;
            buttonResetAll.Enabled = false;

            labelInformation.Text = string.Empty;

            buttonMenu_Click(this, new EventArgs());
            buttonMenuSearch_Click(this, new EventArgs());
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (!ManageCancel("Alcuni download/conversioni sono ancora in corso.\n\nVuoi chiudere comunque l'applicazione?"));
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            settingsManager.AutoDownload = toggleButtonAutoDownload.ToggleState;
            settingsManager.DownloadDirectory = textBoxPath.Text;
            settingsManager.SearchResults = ((int)numericUpDownSearch.Value);

            settingsManager.SaveSettings();
        }
        #endregion

        #region TEXTBOX_EVENT
        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                e.Handled = true;

                buttonSearch_ClickAsync(this, new EventArgs());
            }
        }
        #endregion

        #region BUTTON_EVENT
        private async void buttonSearch_ClickAsync(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxSearch.Text))
            {
                flowLayoutPanelSearch.Controls.Clear();

                if (!flowLayoutPanelSearch.Visible)
                {
                    buttonMenuSearch_Click(this, new EventArgs());
                }

                labelInformation.Text = "Sto cercando...";
                buttonShowAll.Enabled = false;

                try
                {
                    using (YoutubeClient youtubeClient = new YoutubeClient())
                    {
                        string[] videoIds = await youtubeClient.SearchVideoIdAsync(textBoxSearch.Text, ((int)numericUpDownSearch.Value));

                        if (videoIds.Length > 0)
                        {
                            VideoInfo videoInfo = await youtubeClient.GetVideoInfoAsync(videoIds[0]);
                            flowLayoutPanelSearch.Controls.Add(new SearchUserControl(videoInfo));

                            Task<VideoInfo>[] tasks = new Task<VideoInfo>[videoIds.Length - 1];

                            for (int i = 0; i != tasks.Length; i++)
                            {
                                tasks[i] = youtubeClient.GetVideoInfoAsync(videoIds[i + 1]);
                            }

                            videoInfos = await Task.WhenAll(tasks);

                            labelInformation.Text = string.Empty;
                            buttonShowAll.Enabled = true;
                        }
                        else
                        {
                            labelInformation.Text = "Nessun risultato.";
                        }
                    }
                }
                catch (Exception exception)
                {
                    labelInformation.Text = ("Errore: " + exception.Message);
                }
            }
        }
        #endregion

        #region MENUBUTTONS_EVENTS
        private void buttonMenu_Click(object sender, EventArgs e)
        {
            animationManager.AnimateControls = (!animationManager.AnimateControls);

            foreach (DownloadUserControl downloadUserControl in flowLayoutPanelDownload.Controls)
            {
                Padding padding = downloadUserControl.Margin;
                int right = (animationManager.AnimateControls ? (padding.Right - 10) : (padding.Right + 10));

                downloadUserControl.Margin = new Padding(padding.Left, padding.Top, right, padding.Bottom);
            }

            labelAutoDownload.Visible = (!labelAutoDownload.Visible);
        }

        private void buttonMenuSearch_Click(object sender, EventArgs e)
        {
            MenuStatusmanager(true);
        }

        private void buttonMenuDownload_Click(object sender, EventArgs e)
        {
            MenuStatusmanager(false);
        }

        private void MenuStatusmanager(bool isSearch)
        {
            flowLayoutPanelDownload.Visible = (!isSearch);
            flowLayoutPanelSearch.Visible = isSearch;

            buttonResetAll.Visible = (!isSearch);
            buttonShowAll.Visible = isSearch;

            buttonMenuSearch.BackColor = (isSearch ? Color.Silver : Color.Gainsboro);
            buttonMenuDownload.BackColor = (isSearch ? Color.Gainsboro : Color.Silver);
        }
        #endregion

        #region BELOWBUTTONS_EVENTS
        private void buttonShowAll_Click(object sender, EventArgs e)
        {
            int searchUserControlMaxWidth = 0;

            for (int i = 0; i != videoInfos.Length; i++)
            {
                flowLayoutPanelSearch.Controls.Add(new SearchUserControl(videoInfos[i]));

                if (flowLayoutPanelSearch.Controls[i + 1].Width > searchUserControlMaxWidth)
                {
                    searchUserControlMaxWidth = flowLayoutPanelSearch.Controls[i + 1].Width;
                }
            }

            if (flowLayoutPanelSearch.HorizontalScroll.Visible)
            {
                flowLayoutPanelSearch.Controls[flowLayoutPanelSearch.Controls.Count - 1].Padding = new Padding(0, 0, 15, 15);
            }

            foreach (SearchUserControl searchUserControl in flowLayoutPanelSearch.Controls)
            {
                searchUserControl.Width = searchUserControlMaxWidth;
            }

            buttonShowAll.Enabled = false;
        }

        private void buttonPath_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialogPath.ShowDialog() == DialogResult.OK)
            {
                textBoxPath.Text = folderBrowserDialogPath.SelectedPath;
            }
        }

        private void buttonResetAll_Click(object sender, EventArgs e)
        {
            if (ManageCancel("Alcuni download/conversioni sono ancora in corso.\n\nVuoi ripristinare comunque la lista?"))
            {
                flowLayoutPanelDownload.Controls.Clear();
            }
        }
        #endregion

        #region FLOWLAYOUTPANELS_EVENT
        private void flowLayoutPanelContent_ControlRemoved(object sender, ControlEventArgs e)
        {
            e.Control.Dispose();

            if (flowLayoutPanelDownload.Controls.Count == 0)
            {
                buttonResetAll.Enabled = false;
            }
        }
        #endregion

        #region DOWNLOAD
        private void AddToDownload(VideoInfo videoInfo, AudioInfo audioInfo, Action actionToPerform)
        {
            flowLayoutPanelDownload.Controls.Add(new DownloadUserControl(videoInfo, audioInfo, textBoxPath.Text, actionToPerform));

            if (flowLayoutPanelDownload.VerticalScroll.Visible)
            {
                for (int i = 0; i != flowLayoutPanelDownload.Controls.Count; i++)
                {
                    if (i != (flowLayoutPanelDownload.Controls.Count - 1))
                    {
                        flowLayoutPanelDownload.Controls[i].Padding = new Padding(0, 0, 0, 0);
                    }
                    else
                    {
                        flowLayoutPanelDownload.Controls[i].Padding = new Padding(0, 0, 0, 10);
                    }
                }

                flowLayoutPanelDownload.VerticalScroll.Value = flowLayoutPanelDownload.VerticalScroll.Maximum;
            }

            buttonResetAll.Enabled = true;

            if (!toggleButtonAutoDownload.ToggleState)
            {
                buttonMenuDownload_Click(this, new EventArgs());
            }
        }
        #endregion

        #region CANCEL
        private bool ManageCancel(string text)
        {
            bool cancelRequired = true;

            foreach (DownloadUserControl downloadUserControl in flowLayoutPanelDownload.Controls)
            {
                if (downloadUserControl.IsRunning)
                {
                    if (MessageBox.Show(text, "Domanda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        cancelRequired = false;
                    }

                    break;
                }
            }

            return cancelRequired;
        }
        #endregion
    }
}
