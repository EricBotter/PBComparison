using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison.FFmpeg
{
    class Clip : IFFmpegOption
    {
        public Timestamp Begin { get; init; }
        public Timestamp Duration { get; init; }

        public List<string> ToFFmpegOption()
        {
            return new() { "-ss", Begin.ToString(), "-t", Duration.ToString() };
        }
    }
}
