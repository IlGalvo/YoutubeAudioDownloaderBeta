using System;
using System.IO;
using System.Xml.Serialization;

namespace YoutubeAudioDownloaderBeta.Main
{
    public class SettingsManager
    {
        #region GLOBAL_VARIABLES
        public static readonly int MinSearchResults = 1;
        public static readonly int DefaultSearchResults = 5;
        public static readonly int MaxSearchResults = 20;

        #region WRAPPER
        public class Settings
        {
            #region GLOBAL_VARIABLES
            public bool AutoDownload { get; set; }

            private string downloadDirectory;
            public string DownloadDirectory
            {
                get
                {
                    return downloadDirectory;
                }
                set
                {
                    if ((new Uri(value)).IsWellFormedOriginalString())
                    {
                        throw (new ArgumentException(nameof(DownloadDirectory), "Invalid directory path."));
                    }

                    downloadDirectory = value;
                }
            }

            private int searchResults;
            public int SearchResults
            {
                get
                {
                    return searchResults;
                }
                set
                {
                    if ((value < MinSearchResults) && (value > MaxSearchResults))
                    {
                        string message = ("Value must be between " + MinSearchResults + " and " + MaxSearchResults + ".");

                        throw (new ArgumentOutOfRangeException(nameof(SearchResults), message));
                    }

                    searchResults = value;
                }
            }
            #endregion

            #region CONSTRUCTOR
            public Settings()
            {
                AutoDownload = true;
                DownloadDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
                SearchResults = DefaultSearchResults;
            }
            #endregion
        }
        #endregion

        private static readonly string AppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string Directorypath = Path.Combine(AppDataPath, "Youtube Audio Downloader");
        private static readonly string SettingsPath = Path.Combine(Directorypath, "Settings.xml");

        public bool AutoDownload { get { return settings.AutoDownload; } set { settings.AutoDownload = value; } }
        public string DownloadDirectory { get { return settings.DownloadDirectory; } set { settings.DownloadDirectory = value; SaveSettings(); } }
        public int SearchResults { get { return settings.SearchResults; } set { settings.SearchResults = value; SaveSettings(); } }

        private Settings settings;
        #endregion

        #region STATIC
        public static SettingsManager CreateOrLoadSettings()
        {
            SettingsManager settingsManager = new SettingsManager();

            try
            {
                if (!Directory.Exists(Directorypath))
                {
                    Directory.CreateDirectory(Directorypath);
                }

                if (!File.Exists(SettingsPath))
                {
                    settingsManager.SaveSettings();
                }
                else
                {
                    using (StreamReader streamReader = new StreamReader(SettingsPath))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));

                        settingsManager.settings = ((Settings)xmlSerializer.Deserialize(streamReader));
                    }

                    string downloadDirectory = settingsManager.DownloadDirectory;

                    if (!Directory.Exists(downloadDirectory))
                    {
                        Directory.CreateDirectory(downloadDirectory);
                    }
                }
            }
            catch (Exception)
            {
                settingsManager.settings = new Settings();

                settingsManager.SaveSettings();
            }

            return settingsManager;
        }
        #endregion

        #region CONSTRUCTOR
        private SettingsManager()
        {
            settings = new Settings();
        }
        #endregion

        #region SAVE
        public void SaveSettings()
        {
            using (StreamWriter streamWriter = new StreamWriter(SettingsPath))
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(Settings));

                xmlSerializer.Serialize(streamWriter, settings);
            }
        }
        #endregion
    }
}
