using PBComparison.FFmpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison
{
    class Segment
    {
        public InputFile InputFile { get; init; }
        public Clip Clip { get; init; }
        public string TempFilename { get; set; }

        public void CreateTempFile(string filename)
        {
            TempFilename = filename;

            FFmpegOptions options = new();
            options.Add(InputFile, Clip, new OutputFile() { Filename = filename });

            FFmpegRunner runner = new();
            runner.Run(options);
        }

    }
}
