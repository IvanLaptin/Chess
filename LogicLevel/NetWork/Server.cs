using NetworkLevel;
using NetworkLevel.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using DataLevel;
using System.Text.RegularExpressions;

namespace LogicLevel.NetWork
{
    public class Server
    {
        private Socket serverSocket;
        private IDataAccess connection = new DataAccess();

        public void Start()
        {
            if (serverSocket != null)
            {
                Console.WriteLine("Server already started!");
                return;
            }
            try
            {
                IPEndPoint addr = new IPEndPoint(IPAddress.Parse("10.6.6.121"), 2017);
                serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                serverSocket.Bind(addr);
                serverSocket.Listen(5);

                Console.WriteLine("Server started!");

                ThreadPool.QueueUserWorkItem(WaitForConnect);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }

        private void WaitForConnect(object obj)
        {
            Console.WriteLine("Wait for connect");
            try
            {
                while (serverSocket != null)
                {
                    Socket clientSocket = serverSocket.Accept();
                    Console.WriteLine("Connect done from: " + clientSocket.RemoteEndPoint);
                    var user = new User(clientSocket);
                    user.StartReceive();
                    user.MessageReceived += OnMessageReceived;
                    user.UserDisconnected += OnUserDisconnected;
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        private void OnUserDisconnected(User user, string reason)
        {
           
        }

        private void OnMessageReceived(User user, Message message)
        {
            if (message.Type == MessageType.Registration)
            {
                var login = (message as MessageRegistration).Login;
                var password = (message as MessageRegistration).Password;
                var email = (message as MessageRegistration).Email;
                var fullName = (message as MessageRegistration).FullName;
                Regex loginReg = new Regex(@"^.{3,}$");
                Regex passwordReg = new Regex(@"^.{6,}$");
                Regex emailReg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                Regex fullNameReg = new Regex(@"^.{8,}$");
                bool regResult = false;
                if (loginReg.IsMatch(login))
                {
                    if (passwordReg.IsMatch(password))
                    {
                        if (emailReg.IsMatch(email))
                        {
                            if (fullNameReg.IsMatch(fullName))
                            {
                                regResult = connection.SignUp(login, password, email, fullName);
                                user.Send(new MessageRegistrationAnswer() { Answer = regResult });
                            }
                            else
                            {
                                user.Send(new MessageRegistrationAnswer() { Answer = regResult, Reason = "fullName incorrect (less 5 symbols)" });
                            }
                        }
                        else
                        {
                            user.Send(new MessageRegistrationAnswer() { Answer = regResult, Reason = "email incorrect" });
                        }
                    }
                    else
                    {
                        user.Send(new MessageRegistrationAnswer() { Answer = regResult, Reason = "password incorrect (less 6 symbols)" });
                    }
                }
                else
                {
                    user.Send(new MessageRegistrationAnswer() { Answer = regResult, Reason = "login incorrect (less 3 symbols)" });
                }
            }
        }

        public void Stop()
        {
            try
            {
                serverSocket.Close();
                serverSocket = null;
                Console.WriteLine("Server stopped");
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }

        }
    }
}
