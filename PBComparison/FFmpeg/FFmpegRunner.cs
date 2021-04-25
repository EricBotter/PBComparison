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
            ProcessStartInfo processStartInfo = new()
            {
                FileName = "ffmpeg.exe",
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true,
            };

            foreach (var option in options.Render())
            {
                processStartInfo.ArgumentList.Add(option);
            }

            Process process = new()
            {
                StartInfo = processStartInfo
            };

            Console.WriteLine("ffmpeg.exe " + string.Join(' ', options.Render()));

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

            process.WaitForExit(); // kinda useless
            process.Close();
        }
    }
}
