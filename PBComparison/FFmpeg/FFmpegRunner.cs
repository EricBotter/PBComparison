using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

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
                    UseShellExecute = false,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                }
            };

            Console.WriteLine("ffmpeg.exe " + options.Render());

            process.Start();

            using (StreamReader myOutput = process.StandardError)
            {
                while (!process.HasExited)
                {
                    Console.WriteLine(myOutput.ReadLine());
                }
                Console.WriteLine(myOutput.ReadToEnd());
            }

            Console.WriteLine(process.StandardOutput.ReadToEnd()); // should be empty

            process.WaitForExit();
            process.Close();
        }
    }
}
