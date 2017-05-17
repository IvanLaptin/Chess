using NetworkLevel;
using NetworkLevel.Messages.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLevel.NetWork.GameCore
{
    public class Room
    {
        public static int tmp = 0;
        public int Id
        {
            get
            {
                return ++tmp;
            }
        }
        public List<Account> Accounts { get; set; }



    }
}
