using NetworkLevel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace TestClient.Network
{
    class Client : User
    {
        public void Connect()
        {
            try
            {
                if (clientSocket != null) return;

                //EndPoint addr = new IPEndPoint(IPAddress.Parse("10.6.0.116"), 2017);
<<<<<<< HEAD
                //EndPoint addr = new IPEndPoint(IPAddress.Parse("10.6.6.81"), 2017);   // Ivan
                EndPoint addr = new IPEndPoint(IPAddress.Parse("10.6.6.75"), 2017);     // Den
=======
                EndPoint addr = new IPEndPoint(IPAddress.Parse("10.6.6.21"), 2017);
>>>>>>> develop
                clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                clientSocket.Connect(addr);
                Console.WriteLine("Connected!");
                ThreadPool.QueueUserWorkItem(ReceiveMessage);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }
    }
}
