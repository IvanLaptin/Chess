using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public class MessageChangePasswordPassword : Message
    {
        public override MessageType Type
        {
            get { return MessageType.ChangePassword; }
        }

        public string OldPassword { get; set; }
        public string NewPassword { get; set; }

    }
}
