using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace winEssentials
{
    public class CommandH
    {
        public static void Redirect(string command)
        {
            string[] commandSplitted = command.Split(' ');

            if (commandSplitted.Length >= 1)
            {

                if (commandSplitted[0] == "decrash" && 
                    commandSplitted.Length == 1)
                {
                    ProcessManager.listProcesses();
                }
                else if (commandSplitted[0] == "clear" &&
                         commandSplitted.Length == 1) // clear | length = 1
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine(".: winEssential v1 - Beta version :.");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine(".: Coded by Pakrologie & SlayZ :.");
                    Console.WriteLine(".: Free version : Enjoy ! :.");
                    Console.WriteLine("Type /help for list of commands available or visit our website : winEssential.tk");
                    Console.WriteLine(" ");
                    Console.ResetColor();

                }else if (commandSplitted[0] == "open" &&
                          commandSplitted.Length == 2)
                {
                    string url = commandSplitted[1];
                    string WBrowser = WebBrowser.getDefault();
                    if (WBrowser == "unknown")
                    {
                        Utile.WriteMsg("Le navigateur internet n'a pas pu être trouvé !", 2);
                        return;
                    }
                    Process.Start(WBrowser, url);
                    Utile.WriteMsg("Page ouverte avec succès !", 1);
                }else if (commandSplitted[0] == "create" &&
                          commandSplitted.Length >= 4)
                {
                    CreateFiles.createText(commandSplitted[1], commandSplitted[2], commandSplitted);
                }
                else
                {
                    Utile.WriteMsg("Unknown command", 3);
                }

            }
        }
    }
}