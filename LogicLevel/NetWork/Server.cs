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
using DataLevel.Model;
using LogicLevel.NetWork.GameCore;
using NetworkLevel.Messages.GameLogic;
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
                IPEndPoint addr = new IPEndPoint(IPAddress.Parse("10.6.6.64"), 2017);
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
                Regex fullNameReg = new Regex(@"^.{5,}$");
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
            else if (message.Type == MessageType.Disconnect)
            {
                user.Disconnect("User exit");
            }
            else if (message.Type == MessageType.LogIn)
            {
                var login = (message as MessageLogIn).Login;
                var password = (message as MessageLogIn).Password;
                AccountProxy logInResult = null;
                logInResult = connection.LogIn(login, password);
                if (logInResult != null)
                {
                    user.Send(new MessageLogInAnswer() { Answer = true, Login = logInResult.Login, Email = logInResult.Email, FullName = logInResult.FullName, ID = logInResult.Id});
                    AccountList.Instance.Accounts.Add(new Account() { User = user, Login = login, Email = logInResult.Email, FullName = logInResult.FullName, Id = logInResult.Id });
                }
                else
                {
                    user.Send(new MessageLogInAnswer() { Answer = false, Reason = "Incorrect Login/Password" });
                }
            }
            else if(message.Type == MessageType.LogOut)
            {
                var account = AccountList.Instance.Accounts.FirstOrDefault(x => x.User == user);
                if(account != null)
                {
                    AccountList.Instance.Accounts.Remove(account);
                }
            }
            else if(message.Type == MessageType.ChangePassword)
            {
                var account = AccountList.Instance.Accounts.FirstOrDefault(x => x.User == user);
                if(account != null)
                {
                    var newPassword = (message as MessageChangePasswordPassword).NewPassword;
                    var oldPassword = (message as MessageChangePasswordPassword).OldPassword;

                    var logResult = connection.LogIn(account.Login, oldPassword);
                    if (logResult == null)
                    {
                        user.Send(new MessageChangePasswordAnswer() { Answer = false, Reason = "Incorrect old passwort" });
                    }
                    else
                    {
                        Regex passwordReg = new Regex(@"^.{6,}$");
                        if (!passwordReg.IsMatch(newPassword))
                        {
                            user.Send(new MessageChangePasswordAnswer() { Answer = false, Reason = "Incorrect new password (less 6 symbols)" });
                        }
                        else
                        {
                            var changePassResult = connection.ChangePassword(account.Login, newPassword);
                            if (changePassResult)
                            {
                                user.Send(new MessageChangePasswordAnswer() { Answer = true });
                            }
                            else
                            {
                                user.Send(new MessageChangePasswordAnswer() { Answer = false, Reason = "DB error" });
                            }
                        }
                    }
                }
            }
            else if(message.Type == MessageType.StartGameOnline)
            {
                AccountList.Instance.Accounts.FirstOrDefault(u => u.User == user).Type = StatusType.Wait;
                var accounts = AccountList.Instance.Accounts.Where(x => x.Type == StatusType.Wait).ToList();
                //accounts.ForEach(x => x.Type = StatusType.Wait);
                if (AccountList.Instance.Accounts.Where(u=> u.Type == StatusType.Wait).Count() == GameCore.GameCore.RoomCapacity)
                {
                    RoomList.Instance.Rooms.Add(new Room() { Accounts = accounts });
                    SendAll(new MessageStartGameOnlineAnswer() { Accounts = accounts, Answer = StartAnswerType.Start }, accounts);
                }
                else
                {
                    AccountList.Instance.Accounts.FirstOrDefault(x => x.User == user).Type = StatusType.Wait;
                    SendAll(new MessageStartGameOnlineAnswer() { Answer = StartAnswerType.Wait }, accounts);
                }
            }
            else if(message.Type == MessageType.Move)
            {
                
            }


        }


        public void SendAll(Message mes, List<Account> accounts)
        {
            accounts.ForEach(a => a.User.Send(mes));
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
