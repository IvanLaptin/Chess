using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLevel.NetWork.GameCore
{
    public class GameCore
    {
        static Object obj = new object();
        private static GameCore instance = new GameCore();
        public static GameCore Instance 
        { 
            get 
            {
                lock(obj)
                {
                    return instance;
                }
                
            } 
        }
        public const int RoomCapacity = 2;

        private GameCore()
        {
            
        }
    }
}
