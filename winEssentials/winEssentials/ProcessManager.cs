﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace winEssentials
{
    class ProcessManager
    {
        public struct structProcess
        {
            public string name;
            public int id;
        }

        public static void listProcesses()
        {
            bool found = false;

            Utile.WriteMsg("Affichage des processus ne répondant pas ...", 3);

            List<ProcessManager.structProcess> processNotResponding = ProcessManager.getProcessNotResponding();

            int i = 0;

            foreach (ProcessManager.structProcess sp in processNotResponding)
            {
                i++;
                found = true;

                Utile.WriteMsg("ProcessName : " + sp.name + ".exe | ProcessID : " + sp.id, 3);
            }

            Utile.WriteMsg(i + " processus trouvé(s).", 3);
            if (!found)
            {
                return;
            }
            bool finish = false;

            while (!finish && found)
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

                    }
                    else if (commandKillSplitted[1] == "all")
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

        public static List<structProcess> getProcessNotResponding()
        {
            List<structProcess> processNotResponding = new List<structProcess>();

            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (!theprocess.Responding)
                {
                    structProcess spToAdd = new structProcess();
                    spToAdd.name = theprocess.ProcessName;
                    spToAdd.id = theprocess.Id;

                    processNotResponding.Add(spToAdd);
                }
            }

            return processNotResponding;
        }

        public static bool killProcessByID(int id)
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (theprocess.Id == id && !theprocess.Responding)
                {
                    theprocess.Kill();
                    return true;
                }
                
            }
            return false;
        }

        public static bool killAllProcess()
        {
            Process[] processlist = Process.GetProcesses();

            foreach (Process theprocess in processlist)
            {
                if (!theprocess.Responding)
                {
                    theprocess.Kill();
                    return true;
                }
               
            }
            return false;
        }
    }
}
