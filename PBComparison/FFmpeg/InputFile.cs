using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison.FFmpeg
{
    class InputFile : IFFmpegOption
    {
        public string Filename { get; init; }

        public List<string> ToFFmpegOption() => new() { "-i", Filename };
    }
}
