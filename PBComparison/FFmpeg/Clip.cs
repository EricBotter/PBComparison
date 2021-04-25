using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison.FFmpeg
{
    class Clip : IFFmpegOption
    {
        public string Begin { get; init; }
        public string Duration { get; init; }

        public List<string> ToFFmpegOption()
        {
            return new() { "-ss", Begin, "-t", Duration };
        }
    }
}
