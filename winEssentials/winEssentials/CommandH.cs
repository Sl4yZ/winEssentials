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

                    Utile.WriteMsg("Affichage des processus ne répondant pas ...", 3);

                    List<ProcessManager.structProcess> processNotResponding = ProcessManager.getProcessNotResponding();

                    foreach (ProcessManager.structProcess sp in processNotResponding)
                    {
                        found = true;
                       Utile.WriteMsg("ProcessName : " + sp.name + ".exe | ProcessID : " + sp.id, 3);
                    }
                    bool finish = false;

                    if (!found)
                    {
                        Utile.WriteMsg("Aucun processus trouvé(s).", 3);
                        return;
                    }
                       
                   

                    while (!finish)
                    {
                        Utile.WriteMsg("How to use the kill process command : 'kill all' or 'kill [processID]'", 3);

                        string commandKill = Console.ReadLine();
                        string[] commandKillSplitted = commandKill.Split(' ');

                        if (commandKillSplitted.Length == 2)
                        {
                            int result = 0;

                            if (int.TryParse(commandKillSplitted[1], out result))
                            {
                                if (ProcessManager.killProcessByID(result))
                                {
                                    Utile.WriteMsg("Finish", 1);
                                }
                                else
                                    Utile.WriteMsg("Erreur: ID introuvable.", 2);

                            }else if (commandKillSplitted[1] == "all")
                            {
                                if (ProcessManager.killAllProcess())
                                {
                                    Utile.WriteMsg("Finish", 1);
                                }
                                else
                                    Utile.WriteMsg("Erreur : aucun processus n'est bloqué!", 2);

                            }
                            else
                                Utile.WriteMsg("Erreur : argument non reconnu!", 2);
                            finish = true;
                        }
                    }
                }
                else
                {
                    Utile.WriteMsg("Unknown command", 3);
                }
            }
        }
    }
}