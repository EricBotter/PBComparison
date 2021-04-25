using PBComparison.FFmpeg;

namespace PBComparison
{
    class Program
    {
        static void Main(string[] args)
        {
            InputFile inputFile = new() { Filename = "Z:/tmp/xem.mp4" };
            OutputFile outputFile = new() { Filename = "Z:/tmp/out.mp4" };
            Clip clip = new() { Begin = "1", Duration = "1" };
            Filter drawtext = new() { Name = "drawtext", Arguments = @"text=sas:fontfile=C\:/Windows/fonts/Arial.ttf" };

            FFmpegOptions options = new();
            options.Add("-y");
            options.Add(inputFile, clip, drawtext, outputFile);

            FFmpegRunner runner = new();
            runner.Run(options);
        }
    }
}
