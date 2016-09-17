using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winEssentials
{
    public class CommandH
    {
        public static void Redirect(string command)
        {
            string[] commandSplitted = command.Split(' ');

            if (commandSplitted.Length >= 1)
            {
                if (commandSplitted[0] == "decrash") // decrash | length = 1
                {
                    bool found = false;
                    Console.WriteLine("\\ Affichage des processus ne répondant pas //");
                    Console.WriteLine("----------------------------------------------");

                    List<ProcessManager.structProcess> processNotResponding = ProcessManager.getProcessNotResponding();

                    foreach (ProcessManager.structProcess sp in processNotResponding)
                    {
                        found = true;
                        Console.WriteLine("NAME : " + sp.name + " ID : " + sp.id);
                    }

                    Console.WriteLine("----------------------------------------------");
                    bool finish = false;

                    if (!found)
                        return;

                    while (!finish)
                    {
                        Console.WriteLine("' kill [id] ' kill the process with the id or ' kill ' kill all the process which don't responding");

                        string commandKill = Console.ReadLine();
                        string[] commandKillSplitted = commandKill.Split(' ');

                        if (commandKillSplitted.Length == 1)
                        {
                            if (ProcessManager.killAllProcess())
                            {
                                Console.WriteLine("Finish");
                            }
                            else
                                Console.WriteLine("Error : 0x01");

                            finish = true;
                        }
                        else if (commandKillSplitted.Length == 2)
                        {
                            int result;
                            if (int.TryParse(commandKillSplitted[1], out result))
                            {
                                if (ProcessManager.killProcessByID(result))
                                {
                                    Console.WriteLine("Finish");
                                }
                                else
                                    Console.WriteLine("Error : 0x03");
                            }
                            else
                                Console.WriteLine("Error : 0x02");
                            finish = true;
                        }
                    }
                }
            }
        }
    }
}