using NetworkLevel;
using NetworkLevel.Messages;
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
        public List<Player> Players { get; set; }
        Board Board;


        public void Start()
        {
            Board = new Board();
            AccountList.Instance.Accounts.FirstOrDefault(x => x.Id == Players.FirstOrDefault().Id).User.Send(new MessageRequestForStep());
        }


        public void RequestForStep(Player player,Step step)
        {
            Console.WriteLine("RequestForStep");
            var nextPlayer = Players.FirstOrDefault(x => x.Id != player.Id);
            AccountList.Instance.Accounts.FirstOrDefault(x => x.Id == nextPlayer.Id).User.Send(new MessageRequestForStep());
        }


    }
}
