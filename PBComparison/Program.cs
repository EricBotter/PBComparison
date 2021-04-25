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
            Filter drawtext = new()
            { 
                Name = "drawtext",
                Arguments = new() {
                    { "text", "sas" },
                    { "fontfile", "C:/Windows/fonts/Arial.ttf" },
                    { "fontcolor", "white" },
                    { "fontsize", "72" },
                    { "x", "(w-text_w)/2" },
                    { "y", "(h-text_h)/2" },
                },
                Input = "color",
                Output = "a"
            };

            Filter colorSource = new()
            {
                Name = "color",
                Arguments = new()
                {
                    { "color", "black" },
                    { "size", "1920x1080" },
                    { "rate", "60" },
                    { "d", "1" },
                },
                Output = "color"
            };

            Filter scale = new()
            {
                Name = "scale",
                Arguments = new()
                {
                    { "w", "960" },
                    { "h", "540" },
                },
                Output = "scaled"
            };

            Filter overlay = new()
            {
                Name = "overlay",
                Arguments = new()
                {
                    { "x", "0" },
                    { "y", "340" },
                },
                Input = "a][scaled",
            };

            FilterComplex filter = new()
            {
                scale, colorSource, drawtext, overlay
            };

            FFmpegOptions options = new();
            options.Add("-y");
            options.Add(inputFile, clip, filter, outputFile);

            FFmpegRunner runner = new();
            runner.Run(options);
        }
    }
}
