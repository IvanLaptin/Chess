using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
     [Serializable]
    public class MessageLogIn : Message
    {
         public override MessageType Type
         {
             get { return MessageType.LogIn; }
         }

         public string Login { get; set; }
         public string Password { get; set; }
    }
}
