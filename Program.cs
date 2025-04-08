using System;
using System.Diagnostics;
    
namespace SystemProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0)
            {
                RunAsChildProcess(args);
                return;
            }

            RunAsParentProcess();
        }

        static void RunAsChildProcess(string[] args)
        {
            if (args.Length != 3)
            {
                System.Console.WriteLine("Потрібно 3 аргументи: число число операція(+-*/)");
                return;
            }

            try
            {
                double a = double.Parse(args[0]);
                double b = double.Parse(args[1]);
                string op = args[2];

                double result = op switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    _ => throw new System.Exception("Невідома операція")
                };

                System.Console.WriteLine($"Результат: {a} {op} {b} = {result}");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine($"Помилка: {ex.Message}");
            }
        }

        static void RunAsParentProcess()
        {
            while (true)
            {
                System.Console.WriteLine("\nВведіть 3 аргументи (напр. '5 3 +') або 'exit':");
                string input = System.Console.ReadLine();

                if (input == "exit") break;

                string[] arguments = input.Split(' ');

                var process = new System.Diagnostics.Process();
                process.StartInfo.FileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                process.StartInfo.Arguments = string.Join(" ", arguments);
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardOutput = true;

                process.Start();
                System.Console.WriteLine(process.StandardOutput.ReadToEnd());
                process.WaitForExit();
            }
        }
    }
}