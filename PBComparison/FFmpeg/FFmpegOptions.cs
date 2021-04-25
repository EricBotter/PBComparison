using System.Collections.Generic;

namespace PBComparison.FFmpeg
{
    class FFmpegOptions
    {
        public List<IFFmpegOption> Options { get; }

        public FFmpegOptions()
        {
            Options = new List<IFFmpegOption>();
        }

        public FFmpegOptions(List<IFFmpegOption> options)
        {
            Options = options;
        }

        public void Add(params IFFmpegOption[] option)
        {
            Options.AddRange(option);
        }

        public void Add(string option)
        {
            Options.Add(new FFmpegOption(option));
        }

        public string Render()
        {
            return string.Join(' ', Options.ConvertAll(option => option.ToFFmpegOption()));
        }
    }
}