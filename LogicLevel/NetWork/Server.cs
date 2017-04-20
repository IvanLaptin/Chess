﻿using NetworkLevel;
using NetworkLevel.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LogicLevel.NetWork
{
    public class Server
    {
        private Socket serverSocket;

        public void Start()
        {
            if (serverSocket != null)
            {
                Console.WriteLine("Server already started!");
                return;
            }
            try
            {
                //IPEndPoint addr = new IPEndPoint(IPAddress.Parse("10.6.0.116"), 2017);
                //IPEndPoint addr = new IPEndPoint(IPAddress.Parse("10.6.6.81"), 2017); // Ivan
                IPEndPoint addr = new IPEndPoint(IPAddress.Parse("10.6.6.75"), 2017);   //Den
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



                user.Send(new MessageRegistrationAnswer() { Answer = true });
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
