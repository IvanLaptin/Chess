using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public abstract class Message
    {
        public abstract MessageType Type { get; }
    }
}
