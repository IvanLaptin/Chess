using NetworkLevel;
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
        public User User1 { get; set; }
        public User User2 { get; set; }
        StatusGameType GameStatus { get; set; }
    }
}
