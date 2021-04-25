using PBComparison.FFmpeg;
using System;
using System.Collections.Generic;

namespace PBComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            InputFile inputFile = new() { Filename = "Z:/tmp/xem.mp4" };
            OutputFile outputFile = new() { Filename = "Z:/tmp/out.mp4" };
            Clip clip = new() { Begin = "1", Duration = "1" };

            FFmpegOptions options = new(new List<IFFmpegOptionable> { inputFile, clip, outputFile });

            FFmpegRunner runner = new();

            runner.Run(options);
        }
    }
}
