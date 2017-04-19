using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestClient.Network;

namespace TestClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press enter to connect");
            Console.ReadLine();

            var client = new Client();
            client.MessageReceived += client_MessageReceived;
            client.UserDisconnected += client_UserDisconnected;
            client.Connect();

            Console.WriteLine("Enter exit to exit");
            while (true)
            {
                var message = Console.ReadLine();
                if (message == "exit")
                {
                    client.Disconnect("Exit");
                }
                else
                {
                   
                }
            }
        }

        static void client_UserDisconnected(NetworkLevel.User arg1, string arg2)
        {
            
        }

        static void client_MessageReceived(NetworkLevel.User arg1, NetworkLevel.Messages.Message arg2)
        {
            
        }
    }
}
