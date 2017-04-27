using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLevel.NetWork.GameCore
{
    public class RoomList
    {
        public List<Room> Rooms { get; set; }

        public RoomList()
        {
            Rooms = new List<Room>();
        }
    }
}
