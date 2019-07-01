using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace jarwrapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(System.AppDomain.CurrentDomain.FriendlyName);
            var p = RunCmd("java -version");
            p.OutputDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                Console.WriteLine(e.Data);
            });
            p.ErrorDataReceived += new DataReceivedEventHandler((s, e) =>
            {
                Console.WriteLine(e.Data);
            });

            p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine(); 
            p.WaitForExit();
            Console.ReadKey();
        }

        public static Process RunCmd(String command, String fileName = @"C:\Windows\System32\cmd.exe")
        {
            return new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = fileName,
                    Arguments = "/c " + command,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true
                }
            };
        }
    }
}
