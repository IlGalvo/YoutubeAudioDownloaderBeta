using System.ComponentModel;

namespace YoutubeClientManagerBeta.Converter
{
    public delegate void ConvertionProgressEventHandler(object sender, ConversionProgressEventArgs e);

    public delegate void ConvertionFinishedEventHandler(object sender, AsyncCompletedEventArgs e);
}
