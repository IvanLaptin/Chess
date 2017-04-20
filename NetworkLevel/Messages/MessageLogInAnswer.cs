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
    }
}
