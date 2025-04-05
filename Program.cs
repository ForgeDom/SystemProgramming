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
                Console.WriteLine("3. Kill process");
                Console.WriteLine("4. Find process by name");
                Console.WriteLine("5. Exit");
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
                            Console.WriteLine("Choose an option to kill a process:");
                            Console.WriteLine("1. By index");
                            Console.WriteLine("2. By ID");
                            int killChoice = int.Parse(Console.ReadLine());
                        
                            if (killChoice == 1)
                            {
                                var processesToKill = Process.GetProcesses();
                                Console.WriteLine("List length: " + processesToKill.Length);
                                Console.WriteLine("Enter the process index (0 to " + (processesToKill.Length - 1) + "):");
                                int processToKillIndex = int.Parse(Console.ReadLine());
                                if (processToKillIndex >= 0 && processToKillIndex < processesToKill.Length)
                                {
                                    KillProcess(processesToKill[processToKillIndex]);
                                }
                                else
                                {
                                    Console.WriteLine("Invalid index.");
                                }
                            }
                            else if (killChoice == 2)
                            {
                                Console.WriteLine("Enter the process ID:");
                                int processToKillId = int.Parse(Console.ReadLine());
                                var processToKill = Process.GetProcessById(processToKillId);
                                KillProcess(processToKill);
                            }
                            else
                            {
                                Console.WriteLine("Invalid choice.");
                            }
                            break;
                    case 4:
                        Console.WriteLine("Enter the process name:");
                        string processName = Console.ReadLine();
                        FindProcessByName(processName);
                        break;
                    case 5:
                        return;
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
    
        public static void KillProcess(Process processToKill)
        {
            try
            {
                processToKill.Kill();
                Console.WriteLine($"Process {processToKill.ProcessName} (ID: {processToKill.Id}) killed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    
        public static void FindProcessByName(string processName)
        {
            var processes = Process.GetProcessesByName(processName);
            if (processes.Length == 0)
            {
                Console.WriteLine("No process found with the name: " + processName);
            }
            else
            {
                foreach (var process in processes)
                {
                    ShowProcessDetails(process);
                }
            }
        }
    }