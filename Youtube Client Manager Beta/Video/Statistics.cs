namespace YoutubeClientManagerBeta.Video
{
    public sealed class Statistics
    {
        #region GLOBAL_VARIABLES
        public long ViewCount { get; internal set; }
        public long LikeCount { get; internal set; }
        public long DislikeCount { get; internal set; }
        public double AverageRating { get; internal set; }
        #endregion

        #region CONSTRUCTOR
        internal Statistics()
        {
            ViewCount = 0;
            LikeCount = 0;
            DislikeCount = 0;
            AverageRating = 0;
        }
        #endregion
    }
}