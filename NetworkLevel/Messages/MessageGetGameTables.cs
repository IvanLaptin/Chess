using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public class MessageGetGameTables : Message
    {
        public override MessageType Type
        {
            get { return MessageType.GetGameTables; }
        }

        public int Number { get; set; }
        public int Count { get; set; }

    }
}
