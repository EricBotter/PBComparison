using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PBComparison
{
    class FFmpegRunner
    {
        void run()
        {
            Process process = new();
            // Configure the process using the StartInfo properties.
            process.StartInfo.FileName = "ffmpeg.exe";
            process.StartInfo.Arguments = "-version";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            process.Start();
            process.WaitForExit();// Waits here for the process to exit.
        }
    }
}
