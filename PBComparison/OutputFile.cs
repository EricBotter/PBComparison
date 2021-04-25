namespace PBComparison
{
    class OutputFile: IFFmpegOptionable
    {
        public string Filename { get; init; }

        public string ToFFmpegOption() => Filename;
    }
}