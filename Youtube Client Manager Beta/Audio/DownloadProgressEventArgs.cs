using System.ComponentModel;

namespace YoutubeClientManagerBeta.Audio
{
    public sealed class DownloadProgressEventArgs : ProgressChangedEventArgs
    {
        public long BytesReceived { get; }
        public long TotalBytesToReceive { get; }

        internal DownloadProgressEventArgs(long bytesReceived, long totalBytesToReceive, object userState) :
            base(((int)((100 * bytesReceived) / totalBytesToReceive)), userState)
        {
            BytesReceived = bytesReceived;
            TotalBytesToReceive = totalBytesToReceive;
        }
    }
}
