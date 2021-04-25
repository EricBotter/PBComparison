using System.Collections.Generic;

namespace PBComparison.FFmpeg
{
    class FFmpegOptions
    {
        public List<IFFmpegOptionable> Options { get; }

        public FFmpegOptions(List<IFFmpegOptionable> options)
        {
            Options = options;
        }

        public string Render()
        {
            return string.Join(' ', Options.ConvertAll(option => option.ToFFmpegOption()));
        }
    }
}