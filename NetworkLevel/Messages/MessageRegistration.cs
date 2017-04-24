using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages
{
    [Serializable]
    public class MessageRegistration : Message
    {
        public override MessageType Type
        {
            get { return MessageType.Registration; }
        }

        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
    }
}
