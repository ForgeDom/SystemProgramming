using System;
using System.Diagnostics;
    
namespace SystemProgramming
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter the path of the process to start:");
            string processPath = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(processPath))
            {
                processPath = "notepad.exe"; 
                
            }

            Process childProcess = new Process();
            childProcess.StartInfo.FileName = processPath;
            childProcess.StartInfo.UseShellExecute = false;

            try
            {
                Console.WriteLine("\nStarting child process...");
                childProcess.Start();
                Console.WriteLine($"Child process started(ID: {childProcess.Id})");

                Console.WriteLine("\nMake a choice:");
                Console.WriteLine("1 - Waiting for process to exit");
                Console.WriteLine("2 - Finish process forcibly");
                Console.Write("Your choice: ");

                var choice = Console.ReadKey();
                Console.WriteLine();

                switch (choice.KeyChar)
                {
                    case '1':
                        Console.WriteLine("\nWaiting for the process to finish...");
                        childProcess.WaitForExit();
                        Console.WriteLine($"Process finished with code: {childProcess.ExitCode}");
                        break;

                    case '2':
                        Console.WriteLine("\nTrying forcible exit...");
                        try
                        {
                            childProcess.Kill();
                            Console.WriteLine("Process forcibly finbished");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Finished with error: {ex.Message}");
                        }
                        break;

                    default:
                        Console.WriteLine("Wrong choice.");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                try
                {
                    if (!childProcess.HasExited)
                    {
                        Console.WriteLine($"\nWarning: process {childProcess.Id} is still working");
                    }
                }
                catch { }

                Console.WriteLine("\nPress any key to exit...");
                Console.ReadKey();
            }
        }
    }
}