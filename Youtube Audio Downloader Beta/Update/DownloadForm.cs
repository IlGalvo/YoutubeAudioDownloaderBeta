using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace YoutubeAudioDownloaderBeta.Update
{
    public partial class UpdateForm : Form
    {
        #region SAFENATIVE_METHOD
        private static class SafeNativeMethods
        {
            public static bool IsInternetAvailable()
            {
                return (InternetGetConnectedState(out int description, 0));
            }

            [DllImport("Wininet.dll", CallingConvention = CallingConvention.Winapi, CharSet = CharSet.Unicode, SetLastError = true)]
            private extern static bool InternetGetConnectedState(out int description, int reservedValue);
        }
        #endregion

        #region GLOBAL_VARIABLES
        private string fileLink;
        private string versionHistory;
        #endregion

        #region CHECK_UPDATES
        public static DialogResult CheckForUpdates(Version currentVersion, bool notify)
        {
            DialogResult dialogResult = DialogResult.OK;

            if (SafeNativeMethods.IsInternetAvailable())
            {
                try
                {
                    int timeout = ((!notify) ? UpdateUtilities.DefaultTimeout : UpdateUtilities.LongTimeout);

                    using (WebClientTimeout webClientTimeout = new WebClientTimeout(timeout))
                    using (StreamReader streamReader = new StreamReader(webClientTimeout.OpenRead(UpdateUtilities.FileCheckLink)))
                    {
                        Versioning versioning = ((Versioning)new XmlSerializer(typeof(Versioning)).Deserialize(streamReader));

                        if (Version.TryParse(versioning.LatestVersion, out Version latestVersion))
                        {
                            if (currentVersion < latestVersion)
                            {
                                string downloadLink = (UpdateUtilities.DriveDownloadLink + versioning.FileID);

                                using (UpdateForm updateForm = new UpdateForm(downloadLink, versioning.VersionHistory))
                                {
                                    dialogResult = updateForm.ShowDialog();
                                }
                            }
                        }
                        else if (notify)
                        {
                            string text = "Nessun aggiornamento trovato.";

                            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception exception)
                {
                    if ((notify) || (!(exception is WebException)))
                    {
                        MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            return dialogResult;
        }
        #endregion

        #region FORM_EVENTS
        private UpdateForm(string fileLink, string versionHistory)
        {
            InitializeComponent();

            DoubleBuffered = true;

            this.fileLink = fileLink;
            this.versionHistory = versionHistory;
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            richTextBoxVersionHistory.Rtf = (@"{\rtf1\ansi " + versionHistory.Replace("\n", @"\line") + @"}");
        }
        #endregion

        #region BUTTONUPDATE_EVENT
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            PerformNextDownload();

            labelTitle.Text = "AGGIORNAMENTO IN CORSO...";
            labelInfo.Text = UpdateUtilities.UpdateInformation;

            buttonUpdate.Enabled = false;
            buttonCancel.Enabled = false;
        }
        #endregion

        #region BUTTONCANCEL_EVENT
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;

            Close();
        }
        #endregion

        #region DOWNLOAD_MANAGER
        private void PerformNextDownload()
        {
            string fileNamePath = Path.GetTempFileName();

            try
            {
                using (WebClientTimeout webClientTimeout = new WebClientTimeout())
                {
                    webClientTimeout.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                    webClientTimeout.DownloadFileCompleted += WebClient_DownloadFileCompletedUpdate;

                    webClientTimeout.DownloadFileAsync(new Uri(fileLink), fileNamePath, fileNamePath);
                }
            }
            catch (Exception exception)
            {
                File.Delete(fileNamePath);

                MessageBox.Show(exception.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        #endregion

        #region WEBCLIENT_EVENTS
        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            labelCurrentByte.Text = (((e.BytesReceived / 1024f) / 1024f).ToString("00.00") + " Mb");

            coloredProgressBarDownload.Value = e.ProgressPercentage;

            labelTotalByte.Text = (((e.TotalBytesToReceive / 1024f) / 1024f).ToString("00.00") + " Mb");
        }

        private void WebClient_DownloadFileCompletedUpdate(object sender, AsyncCompletedEventArgs e)
        {
            labelInfo.Text = UpdateUtilities.DownloadCompletedInformation;

            using (ZipArchive zipArchive = ZipFile.OpenRead(e.UserState.ToString()))
            {
                zipArchive.Entries[0].ExtractToFile(Path.Combine(Directory.GetCurrentDirectory(), UpdateUtilities.CurrentFileNameTemp));
            }

            File.Delete(e.UserState.ToString());

            File.WriteAllText(UpdateUtilities.FinalizerName, UpdateUtilities.FinalizerContent);
            File.SetAttributes(UpdateUtilities.FinalizerName, FileAttributes.Hidden);

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = UpdateUtilities.FinalizerName,
                CreateNoWindow = true,
                WindowStyle = ProcessWindowStyle.Hidden
            };

            Process.Start(processStartInfo).Dispose();

            DialogResult = DialogResult.None;
            Close();
        }
        #endregion
    }
}
