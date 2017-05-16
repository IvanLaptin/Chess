using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLevel.NetWork.GameCore
{
    public class RoomList
    {
        private static RoomList instance = new RoomList();
        public static RoomList Instance { get { return instance; } }

        public List<Room> Rooms { get; set; }

        private RoomList()
        {
            Rooms = new List<Room>();
        }
    }
}
