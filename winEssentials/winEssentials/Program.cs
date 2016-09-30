using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace winEssentials
{
    class Program
    {

        private static System.Windows.Forms.Timer timer;
        [STAThread]
        static void Main(string[] args)
        {
          
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(".: winEssential v1 - Beta version :.");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine(".: Coded by Pakrologie & SlayZ :.");
            Console.WriteLine(".: Free version : Enjoy ! :.");
            Console.WriteLine("Type /help for list of commands available or visit our website : winEssential.tk");
            Console.WriteLine(" ");
            Console.ResetColor();
            Timer t = new Timer(updateTimer_Tick, null, 0, 1000);
            InitialiseCPUCounter();


            while (true)
            {
                Utile.WriteMsg("Write your command : ");
                winEssentials.CommandH.Redirect(Console.ReadLine());
            }

            
        }
        static void updateTimer_Tick(Object o)
        {
            Console.Title = "winEssentials |";
            Console.Title += " Computer RAM Usage: " + (Convert.ToInt32( ConvertBytesToMegabytes(GetTotalMemoryInBytes())) - InitializeRAMCounter()) + "/" + Convert.ToInt32(ConvertBytesToMegabytes(GetTotalMemoryInBytes())) + " MB";
        }
        static double ConvertBytesToMegabytes(ulong bytes)
        {
            return (bytes / 1024f) / 1024f;
        }
        static ulong GetTotalMemoryInBytes()
        {
            return new Microsoft.VisualBasic.Devices.ComputerInfo().TotalPhysicalMemory;
        }

        public static string InitialiseCPUCounter()
        {
             PerformanceCounter cpuCounter;
            cpuCounter = new PerformanceCounter();

            cpuCounter.CategoryName = "Processor";
            cpuCounter.CounterName = "% Processor Time";
            cpuCounter.InstanceName = "_Total";
            return cpuCounter.NextValue() + "% |";
        }

        public static int InitializeRAMCounter()
        {
            PerformanceCounter ramCounter;
            ramCounter = new PerformanceCounter("Memory", "Available MBytes");
            return Convert.ToInt32(ramCounter.NextValue());

        }

    }
}
