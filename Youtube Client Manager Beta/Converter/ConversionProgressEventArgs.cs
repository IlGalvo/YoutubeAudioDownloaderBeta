using System;
using System.ComponentModel;

namespace YoutubeClientManagerBeta.Converter
{
    public sealed class ConversionProgressEventArgs : ProgressChangedEventArgs
    {
        public TimeSpan CurrentDuration { get; }
        public TimeSpan TotalDuration { get; }

        internal ConversionProgressEventArgs(TimeSpan currentDuration, TimeSpan totalDuration, object userState) :
            base(((int)Math.Round(((100 * currentDuration.TotalSeconds) / totalDuration.TotalSeconds))), userState)
        {
            CurrentDuration = currentDuration;
            TotalDuration = totalDuration;
        }
    }
}
