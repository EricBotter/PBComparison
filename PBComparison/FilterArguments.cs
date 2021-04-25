using System;
using System.Collections.Generic;
using System.Security;

namespace PBComparison
{
    public class FilterArguments
    {
        public Dictionary<string, string> Arguments { get; init; }

        public void Add(string key, string value)
        {
            Arguments.Add(key, value);
        }

        public string Render()
        {
            string output = "";
            foreach (var argument in Arguments)
            {
                output += argument.Key + '=' + Escape(argument.Value);
            }
            return output;
        }

        private string Escape(string value)
        {
            return value
                .Replace(@"\", @"\\")
                .Replace(@"'", @"\'")
                .Replace(@":", @"\:")
            ;
        }
    }
}