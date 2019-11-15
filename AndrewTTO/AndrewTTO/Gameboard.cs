using System;
using System.Collections.Generic;
using System.Text;

namespace AndrewTTO
{
    class Gameboard
    {
        int BOARD_WIDTH = 3;
        int BOARD_LENGTH = 3;
        Tile[,] board = new Tile[3, 3];

        public Gameboard()
        {
            Tile[,] board = new Tile[3, 3];
            for (int row = 0; row < BOARD_LENGTH; row++)
            {
                for (int col = 0; col < BOARD_WIDTH; col++)
                {
                    board[col, row].contents = board.contents;
                }
            }
            
        }

        public override string ToString()
        {
            return Print();
        }

        public string Print()
        {
            string result = "";

            for(int row = 0; row < BOARD_LENGTH; row++)
            {
                for(int col = 0; col < BOARD_WIDTH; col++)
                {
                    result += (board[col, row].contents.ToString());
                    
                    if (col == BOARD_LENGTH-1)
                    {
                        result += "\n";
                    }
                    else
                    {
                        result += "|";
                    }
                }

                result += "--------------------------------" + "\n";

            }
            return result;

        }
    }
}
