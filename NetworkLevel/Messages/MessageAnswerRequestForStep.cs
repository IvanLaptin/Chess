using NetworkLevel.Messages.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public class MessageAnswerRequestForStep : Message
    {
        public override MessageType Type
        {
            get { return MessageType.AnswerStep; }
        }

        public Step Step { get; set; }

    }
}
