using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages.GameLogic
{
    [Serializable]
    public class Step
    {
        public int X;
        public int Y;


        public Step(int x,int y)
        {
            X = x;
            Y = y;
        }
    }
}
