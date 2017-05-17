using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages.GameLogic
{
    [Serializable]
    public class Account
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public StatusType Type { get; set; }
        public User User { get; set; }
    }
}
