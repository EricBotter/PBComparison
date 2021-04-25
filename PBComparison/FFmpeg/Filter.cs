using System;
using System.Collections.Generic;

namespace PBComparison.FFmpeg
{
    class Filter : IFFmpegOption
    {
        public string Input { get; init; } = null;
        public string Output { get; init; } = null;
        public string Name { get; init; }
        public FilterArguments Arguments { get; init; }

        public List<string> ToFFmpegOption()
        {
            return new()
            {
                "-vf",
                (Input == null ? "" : "[" + Input + "]")
                    + Name + "=" + Arguments.Render()
                    + (Output != null ? "[" + Output + "]" : "")
            };
        }
    }
}