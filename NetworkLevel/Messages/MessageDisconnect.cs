using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    class MessageDisconnect : Message
    {
        public override MessageType Type
        {
            get { return MessageType.ChangePasswordSettings; }
        }

    }
}
