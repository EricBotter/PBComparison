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
            string output = "";
            foreach (var option in Options)
            {
                output += option.ToFFmpegOption();
            }
            return output;
        }

    }
}