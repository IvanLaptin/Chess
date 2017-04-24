using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestClient.Network;
using NetworkLevel.Messages;
using DataLevel;

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

            //client.Send(new MessageRegistration() { FullName = "Ivan Laptin", Email = "ivan@gmail.com", Login = "Shtorm", Password = "111" });
            //client.Send(new MessageRegistration() { FullName = "Ivan Laptin", Email = "ivan@gmail.com", Login = "Shtorm", Password = "111111" });
            client.Send(new MessageLogIn() { Login = "Shtorm", Password = "111111" });

            Console.ReadLine();
        }

        static void client_UserDisconnected(NetworkLevel.User arg1, string arg2)
        {
            
        }

        static void client_MessageReceived(NetworkLevel.User user, NetworkLevel.Messages.Message message)
        {
            switch (message.Type)
            {
                case MessageType.Registration:
                    break;
                case MessageType.RegistrationAnswer:
                    Console.WriteLine("RegistrationAnswer - " + (message as MessageRegistrationAnswer));
                    break;
                case MessageType.LogIn:
                    break;
                case MessageType.LogInAnswer:
                    Console.WriteLine("MessageLogInAnswer - " + (message as MessageLogInAnswer));
                    break;
                case MessageType.LogOut:
                    break;
                case MessageType.StartGameWithTheBot:
                    break;
                case MessageType.StartGameOnline:
                    break;
                case MessageType.StartGameOnlineAnswer:
                    break;
                case MessageType.Move:
                    break;
                case MessageType.FinishGame:
                    break;
                case MessageType.YourMove:
                    break;
                default:
                    break;
            }
        }
    }
}
