using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("File Word Counter - Parent Process");
        Console.WriteLine("Enter file path and search word (separated by space):");
        Console.WriteLine(@"Example: C:\files\document.txt bicycle");
        
        string input = Console.ReadLine();
        string[] args = input.Split(new[] { ' ' }, 2, StringSplitOptions.RemoveEmptyEntries);

        if (args.Length != 2)
        {
            Console.WriteLine("Error: You must enter exactly 2 arguments - file path and search word");
            return;
        }

        string filePath = args[0];
        string searchWord = args[1];

        Process childProcess = new Process();
        childProcess.StartInfo.FileName = Process.GetCurrentProcess().MainModule.FileName;
        childProcess.StartInfo.Arguments = $"\"{filePath}\" \"{searchWord}\"";
        childProcess.StartInfo.UseShellExecute = false;
        childProcess.StartInfo.RedirectStandardOutput = true;
        childProcess.StartInfo.CreateNoWindow = true;

        try
        {
            Console.WriteLine("\nStarting child process...");
            childProcess.Start();
            
            string result = childProcess.StandardOutput.ReadToEnd();
            childProcess.WaitForExit();
            
            Console.WriteLine("\nChild process result:");
            Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }

    static void RunAsChildProcess(string[] args)
    {
        if (args.Length != 2)
        {
            Console.WriteLine("Error: Child process requires exactly 2 arguments");
            return;
        }

        string filePath = args[0];
        string searchWord = args[1];
        int count = 0;

        try
        {
            string content = File.ReadAllText(filePath);
            count = CountWordOccurrences(content, searchWord);
            Console.WriteLine($"File: {filePath}");
            Console.WriteLine($"Search word: '{searchWord}'");
            Console.WriteLine($"Occurrences found: {count}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error processing file: {ex.Message}");
        }
    }

    static int CountWordOccurrences(string text, string word)
    {
        int count = 0;
        int index = 0;
        while ((index = text.IndexOf(word, index, StringComparison.OrdinalIgnoreCase)) != -1)
        {
            index += word.Length;
            count++;
        }
        return count;
    }
}