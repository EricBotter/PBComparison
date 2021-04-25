using PBComparison.FFmpeg;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PBComparison.FFmpeg
{
    internal class FilterComplex : IEnumerable<Filter>, IFFmpegOption
    {
        List<Filter> Filters { get; init; }

        public FilterComplex()
        {
            Filters = new();
        }

        public void Add(Filter filter)
        {
            Filters.Add(filter);
        }

        public IEnumerator<Filter> GetEnumerator()
        {
            return ((IEnumerable<Filter>)Filters).GetEnumerator();
        }

        public List<string> ToFFmpegOption()
        {
            return new() {
                "-filter_complex",
                string.Join(";", Filters.Select(filter => filter.FilterValue()))
            };
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)Filters).GetEnumerator();
        }
    }
}