using System;
using System.Diagnostics;
    
namespace SystemProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Choose an option to launch an application:");
                Console.WriteLine("1. Notepad");
                Console.WriteLine("2. Calculator");
                Console.WriteLine("3. Paint");
                Console.WriteLine("4. Other application");
                Console.WriteLine("5. Exit");
                int choice = int.Parse(Console.ReadLine());
    
                switch (choice)
                {
                    case 1:
                        LaunchApplication("notepad.exe");
                        break;
                    case 2:
                        LaunchApplication("calc.exe");
                        break;
                    case 3:
                        LaunchApplication("mspaint.exe");
                        break;
                    case 4:
                        Console.WriteLine("Enter the full path of the application:");
                        string appPath = Console.ReadLine();
                        LaunchApplication(appPath);
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }
    
        static void LaunchApplication(string appPath)
        {
            try
            {
                Process.Start(appPath);
                Console.WriteLine($"Launched {appPath} successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error launching {appPath}: {ex.Message}");
            }
        }
    }
}