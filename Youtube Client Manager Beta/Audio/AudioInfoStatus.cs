using System;
using System.Threading;

namespace YoutubeClientManagerBeta.Audio
{
    internal sealed class AudioInfoStatus
    {
        public CancellationToken Token { get; set; }
        public Exception Error { get; set; }

        public AudioInfoStatus()
        {
            Token = new CancellationToken();
            Error = null;
        }
    }
}
