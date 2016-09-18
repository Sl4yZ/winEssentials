using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sharp.Xmpp.Client;
using Sharp.Xmpp;

namespace CSharp_LoL_Chat_Bot
{
    class Program
    {


        static void Main(string[] args)
        {

            /* connect on port 5222 using TLS/SSL if available */
            using (var client = new XmppClient("pvp.net"))
            {
                client.Hostname = "pvp.net";
                client.Username = "rita85";
                client.Password = "revasta2idgeargottee";
                client.Port = 5223;
                client.Tls = false;
                client.Connect();

                {
                    Console.WriteLine("Connected as " + client.Jid);
                }
            }
            Console.ReadLine();
        }
    }
}
