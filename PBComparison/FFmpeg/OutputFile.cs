using System.Collections.Generic;

namespace PBComparison.FFmpeg
{
    class OutputFile: IFFmpegOption
    {
        public string Filename { get; init; }

        public List<string> ToFFmpegOption() => new() { Filename };
    }
}