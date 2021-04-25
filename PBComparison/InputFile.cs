using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison
{
    class InputFile : IFFmpegOptionable
    {
        public string Filename { get; init; }

        public string ToFFmpegOption() => "-i " + Filename;
    }
}
