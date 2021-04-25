using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace PBComparison.FFmpeg
{
    class FFmpegRunner
    {
        public void Run(FFmpegOptions options)
        {
            Process process = new()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "ffmpeg.exe",
                    Arguments = options.Render(),
                    WindowStyle = ProcessWindowStyle.Hidden,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                }
            };

            process.Start();

            Console.WriteLine(process.StandardError.ReadToEnd());

            process.WaitForExit();// Waits here for the process to exit.
        }
    }
}
