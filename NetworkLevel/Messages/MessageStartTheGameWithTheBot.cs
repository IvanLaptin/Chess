﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public class MessageStartTheGameWithTheBot : Message
    {
        public override MessageType Type
        {
            get { return MessageType.StartGameWithTheBot; }
        }
    }
}
