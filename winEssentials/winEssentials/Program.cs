using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace winEssentials
{
    class Program
    {
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

            while (true)
            {
                Utile.WriteMsg("Write your command : ");
                winEssentials.CommandH.Redirect(Console.ReadLine());
            }

            
        }
        
    }
}
