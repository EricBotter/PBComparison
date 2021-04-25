using PBComparison.FFmpeg;
using System;
using System.Collections.Generic;

namespace PBComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            Clip clip = new() { Begin = "1", Duration = "1" };

            FFmpegOptions options = new(new List<IFFmpegOptionable> { clip });

            FFmpegRunner runner = new();

            runner.Run(options);
        }
    }
}
