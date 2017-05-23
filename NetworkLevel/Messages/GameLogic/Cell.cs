using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages.GameLogic
{
    [Serializable]
    public class Cell
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Figure Figure { get; set; }
    }
}
