using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public class MessageRegistrationAnswer : Message
    {
        public override MessageType Type
        {
            get { return MessageType.RegistrationAnswer; }
        }

        public bool Answer { get; set; }
        public string Reason { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Answer, Reason);
        }
    }
}
