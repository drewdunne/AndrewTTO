using System;
using System.Collections.Generic;
using System.Text;

namespace AndrewTTO
{
    class Gameboard
    {
        public const int BOARD_WIDTH = 3;
        public const int BOARD_LENGTH = 3;
        public Tile[,] tile = new Tile[BOARD_LENGTH, BOARD_WIDTH];

        public Gameboard()
        {
            
            for (int row = 0; row < BOARD_LENGTH; row++)
            {
                for (int col = 0; col < BOARD_WIDTH; col++)
                {
                    tile[col, row] = new Tile();
                    tile[col, row].content = Symbol.empty;
                    
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
                    result += (tile[col, row].ToString());
                    
                    if (col == BOARD_WIDTH-1)
                    {
                        result += "\n";
                    }
                    else
                    {
                        result += "|";
                    }
                }

                if (row != BOARD_LENGTH - 1)
                {
                    result += "------------------" + "\n";
                }

            }

            Console.WriteLine(result);

            return result;

        }
    }
}
