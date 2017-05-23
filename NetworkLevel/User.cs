using NetworkLevel.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace NetworkLevel
{
    [Serializable]
    public class User
    {
        public event Action<User, Message> MessageReceived;
        public event Action<User, string> UserDisconnected;

        protected Socket clientSocket;
        protected Serializer serializer;

        public User()
        {
            serializer = new Serializer();
        }

        public User(Socket clientSocket)
        {
            this.clientSocket = clientSocket;
            serializer = new Serializer();
        }

        public void Send(Message message)
        {
            try
            {
                if (clientSocket.Connected)
                {
                    byte[] data = serializer.Serialize(message);
                    clientSocket.Send(data);
                }
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message);
            }
        }

        public void StartReceive()
        {
            ThreadPool.QueueUserWorkItem(ReceiveMessage);
        }

        public void Disconnect(string reason)
        {
            try
            {
                Console.WriteLine("Client " + clientSocket.RemoteEndPoint + " disconnected");
                if (clientSocket.Connected)
                {
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Disconnect(true);
                }
                if (UserDisconnected != null) UserDisconnected(this, reason);
            }
            catch (Exception err)
            {
                //Console.WriteLine(err.Message);
            }
        }

        protected void ReceiveMessage(object obj)
        {
            try
            {
                if (clientSocket == null) return;
                while (clientSocket.Connected)
                {
                    byte[] data = new byte[clientSocket.ReceiveBufferSize];
                    int count = clientSocket.Receive(data);
                    if (count == 0)
                    {
                        Disconnect("Connection closed on remote side");
                        return;
                    }
                    Message message = serializer.Deserialize(data);
                    if (MessageReceived != null) MessageReceived(this, message);
                }
            }
            catch (Exception err)
            {
                Disconnect(err.Message);
            }
        }

        public string Address { get { return clientSocket.RemoteEndPoint.ToString(); } }
    }
}
