using System.Diagnostics;

namespace SystemProgramming;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. List all processes");
            Console.WriteLine("2. Choose exact process");
            Console.WriteLine("3. Exit");
            int choice = int.Parse(Console.ReadLine());
            
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Press Enter to update the process list...");
                    Console.ReadLine();
                    UpdateProcess(null);
                    break;
                case 2:
                    var processes = Process.GetProcesses();
                    Console.WriteLine("List length: " + processes.Length);
                    Console.WriteLine("Enter the process index (0 to " + (processes.Length - 1) + "):");
                    int processIndex = int.Parse(Console.ReadLine());
                    if (processIndex >= 0 && processIndex < processes.Length)
                    {
                        ShowProcessDetails(processes[processIndex]);
                    }
                    else
                    {
                        Console.WriteLine("Invalid index.");
                    }
                    break;
                case 3:
                    return ;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
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
        Console.WriteLine();
    }
            
    public static void ShowProcessDetails(Process process)
    {
        try
        {
            Console.Clear();
            Console.WriteLine($"Id: {process.Id} | Name: {process.ProcessName}");
            Console.WriteLine($"Memory: {process.WorkingSet64 / 1024 / 1024} MB");
            Console.WriteLine($"Virtual Memory: {process.VirtualMemorySize64 / 1024 / 1024} MB");
            Console.WriteLine($"Start Time: {process.StartTime}");
            Console.WriteLine($"Total Processor Time: {process.TotalProcessorTime}");
            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
            Console.WriteLine();
        }
    }
}