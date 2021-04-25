using PBComparison.FFmpeg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison
{
    class RunCompiler
    {
        public void CompileRun(Run left, Run right)
        {
            var zip = left.Segments.Zip(right.Segments, (leftSegment, rightSegment) => new { leftSegment, rightSegment }).ToList();

            for (int i = 0; i < zip.Count; i++)
            {
                var tuple = zip[i];

                Segment leftSegment = tuple.leftSegment;
                Segment rightSegment = tuple.rightSegment;

                var minDuration = Timestamp.Min(leftSegment.Clip.Duration, rightSegment.Clip.Duration);

                new Segment()
                {
                    InputFile = leftSegment.InputFile,
                    Clip = new() { Begin = leftSegment.Clip.Begin, Duration = minDuration }
                }.CreateTempFile("left_" + i + "_before");

                new Segment()
                {
                    InputFile = rightSegment.InputFile,
                    Clip = new() { Begin = rightSegment.Clip.Begin, Duration = minDuration }
                }.CreateTempFile("right_" + i + "_before");

                if (leftSegment.Clip.Duration < rightSegment.Clip.Duration)
                {
                    leftSegment.CreateFreezeFrame("left_" + i + "_freeze");

                    new Segment()
                    {
                        InputFile = rightSegment.InputFile,
                        Clip = new() { Begin = rightSegment.Clip.Begin + minDuration, Duration = rightSegment.Clip.Duration - minDuration }
                    }.CreateTempFile("right_" + i + "_difference");


                }

            }
        }
    }
}
