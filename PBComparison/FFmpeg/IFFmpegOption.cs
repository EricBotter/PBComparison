using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison.FFmpeg
{
    interface IFFmpegOption
    {
        List<string> ToFFmpegOption();
    }
}
