namespace YoutubeAudioDownloaderBeta.Update
{
    public class Versioning
    {
        public string LatestVersion { get; set; }
        public string FileID { get; set; }
        public string VersionHistory { get; set; }

        public Versioning()
        {
            LatestVersion = string.Empty;
            FileID = string.Empty;
            VersionHistory = string.Empty;
        }
    }
}
