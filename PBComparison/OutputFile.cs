namespace PBComparison
{
    class OutputFile: IFFmpegOption
    {
        public string Filename { get; init; }

        public string ToFFmpegOption() => Filename;
    }
}