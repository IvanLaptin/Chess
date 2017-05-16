using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
     [Serializable]
    public class MessageLogInAnswer : Message
    {
         public override MessageType Type
         {
             get { return MessageType.LogInAnswer; }
         }

         public bool Answer { get; set; }
         public string Reason { get; set; }


         public string Login { get; set; }
         public string Email { get; set; }
         public string FullName { get; set; }
         public int ID { get; set; }

         public override string ToString()
         {
             if (Answer)
             {
                 return string.Format("Login - {0}, Email - {1}, FullName - {2}, ID - {3}", Login, Email, FullName, ID);
             }
             else
             {
                 return string.Format("Reason - {0}", Reason);
             }
         }
    }
}
