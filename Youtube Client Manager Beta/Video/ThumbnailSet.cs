namespace YoutubeClientManagerBeta.Video
{
    public sealed class ThumbnailSet
    {
        #region GLOBAL_VARIABLES
        private readonly string videoId;

        public string LowResolutionUrl { get { return ($"https://img.youtube.com/vi/{videoId}/default.jpg"); } }
        public string MediumResolutionUrl { get { return ($"https://img.youtube.com/vi/{videoId}/mqdefault.jpg"); } }
        public string HighResolutionUrl { get { return ($"https://img.youtube.com/vi/{videoId}/hqdefault.jpg"); } }
        #endregion

        #region CONSTRUCTOR 
        internal ThumbnailSet(string videoId)
        {
            this.videoId = videoId;
        }
        #endregion
    }
}