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

            string pythonScriptPath = @"C:\Users\MAQ\Music\get_list.py";
            //string pythonScriptPath = @"xmlParserV2.py";
            string functioname = "main";
            string qlik_tenant_url = "https://uytp9tpbd684baf.sg.qlikcloud.com/";
            string api_key = "eyJhbGciOiJFUzM4NCIsImtpZCI6IjRmZmU4ZWU2LTIxNTgtNDY0My1iNGE0LTgzZTgxNjBmYjBjNiIsInR5cCI6IkpXVCJ9.eyJzdWJUeXBlIjoidXNlciIsInRlbmFudElkIjoiTkhwaXphMThhU1VwXzQyaEhOemx4Q1hBdEJkRm5pTlciLCJqdGkiOiI0ZmZlOGVlNi0yMTU4LTQ2NDMtYjRhNC04M2U4MTYwZmIwYzYiLCJhdWQiOiJxbGlrLmFwaSIsImlzcyI6InFsaWsuYXBpL2FwaS1rZXlzIiwic3ViIjoiNjQ3NDY4OTM3M2FjOGNiNTFlMzQxNTU1In0.f8VwBYAcBvxSuuo2hhLG3u2GPCZXkjAtufr8a63ohGIxb9pI7XCKqzOn3DXK5mFGjOh7Znb43iLy41TK1h4RBqdiyTwom8n19lFYbBUq3aSG8JWrEJWZo13wBfDiYyk7";
            string parameters = String.Format("{0} | {1} | {2} | {3}", pythonScriptPath, functioname, qlik_tenant_url, api_key);

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

                    string[] lines = result.Split('\n');
                    //Console.WriteLine(lines.Length);
                    List<string> appList = new List<string>();
                    foreach (string line in lines)
                    {
                        //Console.WriteLine("new");
                        //Console.WriteLine(line);
                        bool app = line.Contains("App Name");
                        if (app)
                        {
                            //Console.WriteLine(line);
                            appList.Add(line);
                        }
                    }
                    foreach (string app_name in appList)
                    {
                        Console.WriteLine(app_name);
                    }
                }
            }

        }
    }
}