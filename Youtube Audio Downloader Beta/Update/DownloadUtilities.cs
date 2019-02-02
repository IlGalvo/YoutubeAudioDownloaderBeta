using System;

namespace YoutubeAudioDownloaderBeta.Update
{
    internal static class UpdateUtilities
    {
        #region GENERAL
        public static string ProcessArguments { get { return ("/passive"); } }

        public static string CurrentFileNameTemp { get { return AppDomain.CurrentDomain.FriendlyName.Replace(".exe", ".tmp"); } }
        #endregion

        #region TIMEOUT
        public static int DefaultTimeout { get { return 2000; } }

        public static int LongTimeout { get { return 3500; } }
        #endregion

        #region LINK
        public static string FileCheckLink
        {
            get
            {
                return ("https://onedrive.live.com/download?resid=7D7FF9DFDA23C644!2368&authkey=!AFcY04VNisbcdlE");
            }
        }
        #endregion

        #region LABELINFO
        public static string UpdateInformation { get { return ("Sto scaricando l'aggiornamento..."); } }

        public static string DownloadCompletedInformation { get { return ("Scaricamento completato. Avvio installazione."); } }
        #endregion

        #region FINALIZER
        public static string FinalizerName { get { return ("Finalizer.bat"); } }

        public static string FinalizerContent
        {
            get
            {
                return ("@echo off\n" +
                    "timeout /t 1 /nobreak > nul\n" +
                    "del \"" + AppDomain.CurrentDomain.FriendlyName + "\"\n" +
                    "ren \"" + CurrentFileNameTemp + "\" \"" + AppDomain.CurrentDomain.FriendlyName + "\"\n" +
                    "start \"\" \"" + AppDomain.CurrentDomain.FriendlyName + "\"\n" +
                    "del /a:h \"" + FinalizerName + "\"");
            }
        }
        #endregion
    }
}
