using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetworkLevel.Messages.GameLogic
{
    [Serializable]
    public class Board
    {
        List<Cell> Cells;
      //  Cell[,] board = new Cell[10, 10]; 

        public Board()
        {
            Cells = new List<Cell>();
            Initialize();
        }

        public void Initialize()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Cells.Add(new Cell() { X = i ,Y = j });
                }
            }
        }
    }


    



}
