using System.Collections.Generic;

namespace YoutubeClientManagerBeta.Audio.Itag
{
    internal static class ItagInfo
    {
        #region GLOBAL_VARIABLE
        private static readonly Dictionary<int, ItagDescriptor> ItagMap = new Dictionary<int, ItagDescriptor>()
        {
            // Default
            {0, new ItagDescriptor(AudioContainer.Unknown, AudioEncoding.Unknown)},

            // Audio-only (mp4)
            {139, new ItagDescriptor(AudioContainer.M4A, AudioEncoding.Aac)},
            {140, new ItagDescriptor(AudioContainer.M4A, AudioEncoding.Aac)},
            {141, new ItagDescriptor(AudioContainer.M4A, AudioEncoding.Aac)},
            {256, new ItagDescriptor(AudioContainer.M4A, AudioEncoding.Aac)},
            {258, new ItagDescriptor(AudioContainer.M4A, AudioEncoding.Aac)},
            {325, new ItagDescriptor(AudioContainer.M4A, AudioEncoding.Aac)},
            {328, new ItagDescriptor(AudioContainer.M4A, AudioEncoding.Aac)},

            // Audio-only (webm)
            {171, new ItagDescriptor(AudioContainer.WebM, AudioEncoding.Vorbis)},
            {172, new ItagDescriptor(AudioContainer.WebM, AudioEncoding.Vorbis)},
            {249, new ItagDescriptor(AudioContainer.WebM, AudioEncoding.Opus)},
            {250, new ItagDescriptor(AudioContainer.WebM, AudioEncoding.Opus)},
            {251, new ItagDescriptor(AudioContainer.WebM, AudioEncoding.Opus)}
        };
        #endregion

        #region CONTAINER
        public static AudioContainer GetContainer(int itag)
        {
            return (ItagMap[itag].Container);
        }
        #endregion

        #region ENCODING
        public static AudioEncoding GetEncoding(int itag)
        {
            return (ItagMap[itag].Encoding);
        }
        #endregion
    }
}