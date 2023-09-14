using System;
using System.IO;
using System.Diagnostics;
using System.Data.SqlTypes;

namespace demo1
{
    class Program
    {
        static void Main(string[] args)
        {

            string pythonScriptPath = @""; // give the python script path here
            //string pythonScriptPath = @"xmlParserV2.py";
            string functioname = "main";
            string ffmpeg_path = ""; // give the ffmpeg path here
            string parameters = String.Format("\"{0}\" | \"{1}\" | \"{2}\"", pythonScriptPath, functioname, ffmpeg_path);

            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "python",
                //Arguments = $"{pythonScriptPath} {functioname} {parameter}",
                Arguments = parameters,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                CreateNoWindow = false
            };

            using (Process process = Process.Start(startInfo))
            {
                using (StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd();
                    Console.WriteLine(result);

                }
            }

        }
    }
}