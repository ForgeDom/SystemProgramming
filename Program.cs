using System;
using System.Diagnostics;
    
namespace SystemProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Process childProcess = new Process();
            childProcess.StartInfo.FileName = "notepad.exe";
            childProcess.StartInfo.UseShellExecute = false;
            
            Console.WriteLine("Starting child process...");
            try
            {
                childProcess.Start();
                childProcess.WaitForExit();
                
                int exitCode = childProcess.ExitCode;
                Console.WriteLine($"Child process exited with code: {exitCode}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}