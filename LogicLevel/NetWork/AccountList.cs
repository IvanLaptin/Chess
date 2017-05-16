using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetworkLevel.Messages.GameLogic;


namespace LogicLevel.NetWork
{
    
    public class AccountList
    {
        private static AccountList instance = new AccountList();
        public List<Account> Accounts { get; set; }

        private AccountList()
        {
            Accounts = new List<Account>();
        }

        public static AccountList Instance { get { return instance; } }
    }
}
