using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages.GameLogic
{
    public class Player
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public StartPositionType StartPositionType { get; set; }
        public int CountKilledCheckers { get; set; }

        public Player(int id,string login, StartPositionType type)
        {
            Id = id;
            Login = login;
            StartPositionType = type;
        }

        public static List<Player> GetListPlayers(List<Account> accounts)
        {
            List<Player> players = new List<Player>();

            int s = 0;
            foreach (var item in accounts)
            {
                if (s == 0)
                {
                    players.Add(new Player(item.Id, item.Login, StartPositionType.Top));
                    s++;
                }
                else
                {
                    players.Add(new Player(item.Id, item.Login, StartPositionType.Bottom));
                }
            }
            return players;
        }

    }
}
