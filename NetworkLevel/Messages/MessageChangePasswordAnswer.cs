using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public class MessageChangePasswordAnswer : Message
    {
        public override MessageType Type
        {
            get { return MessageType.ChangePasswordAnswer; }
        }

        public bool Answer { get; set; }
        public string Reason { get; set; }

        public override string ToString()
        {
            if (Answer)
            {
                return string.Format("Answer: {0}", Answer);
            }
            else
            {
                return string.Format("Answer: {0}, Reason: {1}", Answer, Reason);
            }
        }

    }
}