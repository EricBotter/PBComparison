using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace PBComparison.FFmpeg
{
    public class FilterArguments : IEnumerable<KeyValuePair<string, string>>
    {
        public Dictionary<string, string> Arguments { get; init; }

        public FilterArguments()
        {
            Arguments = new();
        }

        public void Add(string key, string value)
        {
            Arguments.Add(key, value);
        }

        public string Render()
        {
            return string.Join(':', Arguments.Select(argument => argument.Key + '=' + Escape(argument.Value)));
        }

        private string Escape(string value)
        {
            return value
                .Replace(@"\", @"\\")
                .Replace(@"'", @"\'")
                .Replace(@":", @"\:")
            ;
        }

        public IEnumerator GetEnumerator()
        {
            return ((IEnumerable)Arguments).GetEnumerator();
        }

        IEnumerator<KeyValuePair<string, string>> IEnumerable<KeyValuePair<string, string>>.GetEnumerator()
        {
            return Arguments.GetEnumerator();
        }
    }
}