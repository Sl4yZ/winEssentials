using System;
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
