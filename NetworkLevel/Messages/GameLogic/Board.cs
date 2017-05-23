using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages.GameLogic
{
    public class Board
    {
        int[,] board = new int[10,10]; 

        public Board()
        {
            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    board[i, j] = j;
                }
            }
        }
    }
}
