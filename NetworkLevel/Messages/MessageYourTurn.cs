using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    public class MessageYourTurn : Message
    {
        public override MessageType Type
        {
            get { return MessageType.YourMove; }
        }
    }
}
