using PBComparison.FFmpeg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison
{
    class Run
    {
        public List<Segment> Segments { get; } = new List<Segment>();
        private InputFile InputFile { get; init; }

        public void Add(string duration)
        {
            Segments.Add(new()
            {
                InputFile = InputFile,
                Clip = new()
                {
                    Begin = Segments.Last().Clip.Begin + Segments.Last().Clip.Duration,
                    Duration = duration
                }
            });
        }
    }
}
