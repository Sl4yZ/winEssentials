using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace winEssentials
{
    class Utile
    {
        public static void WriteMsg(string text, int type = 0)
        {
            // 0 : NORMAL | 1 : SUCCESS | 2 : ERROR | 3 : INFORMATION
            //Console.SetCursorPosition((Console.WindowWidth - text.Length) / 2, Console.CursorTop);
            switch (type)
            {
                case 1:
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    break;
                case 2:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case 3:
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                    break;
            }
            Console.WriteLine("-> " + text);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}