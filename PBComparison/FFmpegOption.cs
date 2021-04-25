﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace PBComparison
{
    class FFmpegOption : IFFmpegOption
    {
        public string Content { get; init; }

        public FFmpegOption(string content)
        {
            Content = content;
        }

        public string ToFFmpegOption()
        {
            return Content;
        }
    }
}
