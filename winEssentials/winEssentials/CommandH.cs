using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace winEssentials
{
    public class CommandH
    {
        public static void Redirect(string command)
        {
            try
            {
                string[] commandSplitted = command.Split(' ');

                if (commandSplitted.Length >= 1)
                {
                    if (commandSplitted[0] == "uncrash" && commandSplitted.Length == 1)
                    {
                        ProcessManager.listProcesses();
                    }
                    else if (commandSplitted[0] == "clear" && commandSplitted.Length == 1)
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

                    }
                    else if (commandSplitted[0] == "open" && (commandSplitted.Length == 2 || commandSplitted.Length == 1))
                    {
                        string url = commandSplitted[1];
                        string WBrowser = WebBrowsers.getDefault();
                        if (WBrowser == "unknown")
                        {
                            Utile.WriteMsg("Le navigateur internet n'a pas pu être trouvé !", 2);
                            return;
                        }
                        Process.Start(WBrowser, url);
                        Utile.WriteMsg("Page ouverte avec succès !", 1);
                    }
                    else if (commandSplitted[0] == "create" && commandSplitted[1] == "txt" && commandSplitted.Length >= 5)
                    {
                        CreateFiles.createText(commandSplitted[2], commandSplitted[3], commandSplitted);
                    }
                    else if (commandSplitted[0] == "kill" && commandSplitted.Length == 2)
                    {
                        ProcessManager.killProcessesHdl(commandSplitted[1]);
                    }
                    else if (commandSplitted[0] == "download" && commandSplitted[1] == "youtube" && commandSplitted[2] == "mp3" && (commandSplitted[3].StartsWith("https://www.youtube.com/watch?v=") || 
                        commandSplitted[2].StartsWith("http://www.youtube.com/watch?v="))
                        && commandSplitted.Length == 4)
                    {
                        YoutubeAudio.downloadAudio(commandSplitted[2]);
                    }
                    else if (commandSplitted[0] == "help")
                    {
                        Utile.WriteMsg("____________________________________");
                        Utile.WriteMsg("Open a webpage : open OR open <url>");
                        Utile.WriteMsg("Create a text file : create txt <desk|doc|music|picture|video|pathComplete> <fileName> <content>");
                        Utile.WriteMsg("List processes that are not responding : uncrash");
                        Utile.WriteMsg("Download an MP3 from YouTube : download youtube mp3 <url>");
                        Utile.WriteMsg("_____________________________________");
                    }
                    else if (commandSplitted[0] == "scratch" && commandSplitted.Length == 1)
                    {
                        ProcessManager.cleanDesktop();
                        Utile.WriteMsg("Tous les processeurs n'étant pas important pour le fonctionnement de Windows viennent d'être arrêtés", 1);
                    }
                    else
                    {
                        Utile.WriteMsg("Unknown command", 3);
                    }
                }
            }
            catch (Exception ex)
            {
                Utile.WriteMsg("Unknown command", 3);
            }

        }
    }
}