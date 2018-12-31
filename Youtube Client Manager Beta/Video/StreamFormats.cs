namespace YoutubeClientManagerBeta.Video
{
    internal sealed class StreamFormat
    {
        public bool IsAdaptive { get; set; }
        public string Url { get; set; }

        public StreamFormat()
        {
            IsAdaptive = false;
            Url = string.Empty;
        }
    }
}
