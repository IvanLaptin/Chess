using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public class MessageStartGameOnlineAnswer : Message
    {
        public override MessageType Type
        {
            get { return MessageType.StartGameOnlineAnswer; }
        }

        public StartAnswerType Answer { get; set; }


        
    }
}
