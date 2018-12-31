namespace YoutubeClientManagerBeta.Converter
{
    internal sealed class ConverterStatus
    {
        public bool Cancelled { get; set; }
        public object UserToken { get; set; }

        public ConverterStatus(object userToken = null)
        {
            Cancelled = false;
            UserToken = userToken;
        }
    }
}
