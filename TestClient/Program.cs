using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestClient.Network;
using NetworkLevel.Messages;
using DataLevel;
using NetworkLevel.Messages.GameLogic;

namespace TestClient
{
    class Program
    {
        static Client client;
        static void Main(string[] args)
        {

            Console.WriteLine("Press enter to connect");
            Console.ReadLine();

            client = new Client();
            client.MessageReceived += client_MessageReceived;
            client.UserDisconnected += client_UserDisconnected;
            client.Connect();

            Console.WriteLine("Enter exit to exit");

            //client.Send(new MessageRegistration() { FullName = "RAMBO", Email = "rembo1@gmail.com", Login = "rambo1", Password = "111111" });
            //client.Send(new MessageRegistration() { FullName = "RAMBO2", Email = "rembo2@gmail.com", Login = "rambo2", Password = "111111" });
            //client.Send(new MessageRegistration() { FullName = "RAMBO3", Email = "rembo3@gmail.com", Login = "rambo3", Password = "111111" });



            //client.Send(new MessageLogIn() { Login = "rambo1", Password = "111111" });
            //client.Send(new MessageStartGameOnline());



            //client.Send(new MessageLogIn() { Login = "rambo2", Password = "111111" });
            //client.Send(new MessageStartGameOnline());

            client.Send(new MessageLogIn() { Login = "rambo3", Password = "111111" });
           





            //client.Send(new MessageRegistration() { FullName = "RAMBO3", Email = "rembo@gmail.com", Login = "rambo", Password = "111111" });


            //client.Send(new MessageLogIn() { Login = "rambo", Password = "222222" });
            
            

            
            //client.Send(new MessageLogIn() { Login = "Shtorm", Password = "1111112" });
            //client.Send(new MessageChangePasswordPassword() { OldPassword = "111111", NewPassword = "222222" });
            //client.Send(new MessageLogIn() { Login = "RAMBO", Password = "111111" });
            //client.Send(new MessageLogIn() { Login = "RAMBO", Password = "222222" });

            Console.ReadLine();
        }

        static void client_UserDisconnected(NetworkLevel.User arg1, string arg2)
        {
            
        }

        static void client_MessageReceived(NetworkLevel.User user, NetworkLevel.Messages.Message message)
        {
            switch (message.Type)
            {
                case MessageType.RegistrationAnswer:
                    Console.WriteLine("RegistrationAnswer - " + (message as MessageRegistrationAnswer));
                    break;
                case MessageType.LogInAnswer:
                    Console.WriteLine("MessageLogInAnswer - " + (message as MessageLogInAnswer));
                    client.Send(new MessageStartGameOnline());
                    break;
                case MessageType.RequestStep:
                    Console.WriteLine("RequestStep");
                    client.Send(new MessageAnswerRequestForStep() { Step = new Step(1, 1) });
                    break;
                case MessageType.LogOut:
                    break;
                case MessageType.StartGameWithTheBot:
                    break;
                case MessageType.StartGameOnline:
                    break;
                case MessageType.StartGameOnlineAnswer:
                    Console.WriteLine((message as MessageStartGameOnlineAnswer).Answer);
                    break;
                case MessageType.FinishGame:
                    break;
                case MessageType.YourMove:
                    break;
                case MessageType.ChangePasswordAnswer:
                    Console.WriteLine("ChangePasswordAnswer - " + (message as MessageChangePasswordAnswer));
                    break;
                default:
                    break;
            }
        }
    }
}
