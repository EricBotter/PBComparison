using System;

namespace PBComparison
{
    class Filter : IFFmpegOption
    {
        public string Input { get; init; } = null;
        public string Output { get; init; } = null;
        public string Name { get; init; }
        public FilterArguments Arguments { get; init; }

        public string ToFFmpegOption()
        {
            return "-vf "
                + (Input == null ? "" : "[" + Input + "]")
                + Name + "=" + Arguments.Render()
                + (Output != null ? "[" + Output + "]" : "")
            ;
        }

        private string Escape(string arguments)
        {
            return arguments;
        }
    }
}