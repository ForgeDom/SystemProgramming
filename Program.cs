using System.Diagnostics;
namespace SystemProgramming;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Press Enter to update the process list...");
            Console.ReadLine();
            UpdateProcess(null);
        }
    }

    public static void UpdateProcess(object state)
    {
        var processItem = Process.GetProcesses();
        Console.Clear();
        foreach (var process in processItem)
        {
            Console.WriteLine($"Id: {process.Id} | Name: {process.ProcessName} | Memory: {process.WorkingSet64 / 1024 / 1024} MB");
            Console.WriteLine($"Virtual Memory: {process.VirtualMemorySize64 / 1024 / 1024} MB");
            Console.WriteLine();
        }
        Console.WriteLine("Updated at: " + DateTime.Now);
    }
}