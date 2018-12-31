using System;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;
using YoutubeAudioDownloaderBeta.Main;
using YoutubeAudioDownloaderBeta.Update;

namespace YoutubeAudioDownloaderBeta
{
    public static class MainProgram
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        public static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            using (Mutex mutex = new Mutex(false, (Application.ProductName + "_" + Assembly.GetExecutingAssembly().GetType().GUID.ToString())))
            {
                if (mutex.WaitOne(0, false))
                {
                    if (UpdateForm.CheckForUpdates(new Version(Application.ProductVersion), false) == DialogResult.OK)
                    {
                        WebBrowserPrepare.SetBrowserFeatureControl();

                        Application.Run(new MainForm());
                    }
                }
                else
                {
                    string text = "Non sono consentite istanze multiple, al momento.";
                    MessageBox.Show(text, "Avviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
