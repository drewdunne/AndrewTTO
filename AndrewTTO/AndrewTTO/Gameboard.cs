using System;
using System.Collections.Generic;
using System.Text;

namespace AndrewTTO
{
    class Gameboard
    {
        public Gameboard()
        {
            Tile[,] board = new Tile[3, 3];

        }

        public override string ToString()
        {
            return Tile;
        }

        public void Print(Gameboard board)
        {
            Console.WriteLine(board.ToString());
        }
    }
}
