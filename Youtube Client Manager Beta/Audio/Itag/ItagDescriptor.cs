namespace YoutubeClientManagerBeta.Audio.Itag
{
    internal sealed class ItagDescriptor
    {
        #region GLOBAL_VARIABLES
        public AudioContainer Container { get; }
        public AudioEncoding Encoding { get; }
        #endregion

        #region CONSTRUCTOR
        public ItagDescriptor(AudioContainer container, AudioEncoding encoding)
        {
            Container = container;
            Encoding = encoding;
        }
        #endregion
    }
}