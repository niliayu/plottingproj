using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApplication
{
    public static class RunPython
    {
        public static void Run(string delta, string building)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "python.exe";
            string pyscript = "scrape_script.py";
            string args = building + " " + delta;
            start.Arguments = string.Format("{0} {1}", pyscript, args);
//            start.UseShellExecute = false;
//            start.RedirectStandardOutput = true;
//            start.RedirectStandardError = true;
//            start.CreateNoWindow = false;
//            start.WindowStyle = ProcessWindowStyle.Hidden;

            Process pyprocess = new Process();
            pyprocess.StartInfo = start;
            pyprocess.Start();


//            try
//            {
//                StreamReader outputReader = pyprocess.StandardOutput;
//                StreamReader errReader = pyprocess.StandardError;
//
//                string csvfilename = null;
//                while (!pyprocess.HasExited && csvfilename == null && !outputReader.EndOfStream)
//                {
//                    while (outputReader.Peek() >= 0 && outputReader.ReadLine() != null)
//                    {
//                        csvfilename = outputReader.ReadLine();
//                        Console.WriteLine("This should not print");
//                    }
//
////                    Console.WriteLine(outputReader.ReadLine());
//                    Console.WriteLine(errReader.ReadToEnd());
//                }
//                Console.WriteLine("This should print");
//            }
//            catch(Exception ex)
//            {
//                Console.WriteLine(ex.StackTrace);
//            }

        }
    }
}