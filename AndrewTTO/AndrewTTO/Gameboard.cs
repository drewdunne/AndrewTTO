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
                    tile[col, row].x_cord = col;
                    tile[col, row].y_cord = row;
                    tile[col, row].ID = (row * 3) + (col + 1); // Grid ID starting at 1 and going up to 9.
                    
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
                result += " \n     |     |     \n";
                for (int col = 0; col < BOARD_WIDTH; col++)
                {
                    result += $"  {tile[col, row].ToString()}  ";
                    
                    if (col != BOARD_WIDTH-1)
                    {
                        result += "|";
                    }
                    else
                    {
                        result += "\n";
                    }
                }

                if (row != BOARD_LENGTH - 1)
                {
                    result += "_____|_____|_____";
                }

            }

            Console.WriteLine(result);

            return result;

        }

        public string PrintHelpKey()
        {
            string result = "";

            for (int row = 0; row < BOARD_LENGTH; row++)
            {
                result += " \n     |     |     \n";
                for (int col = 0; col < BOARD_WIDTH; col++)
                {
                    result += $"  {tile[col, row].ID}  ";

                    if (col != BOARD_WIDTH - 1)
                    {
                        result += "|";
                    }
                    else
                    {
                        result += "\n";
                    }
                }

                if (row != BOARD_LENGTH - 1)
                {
                    result += "_____|_____|_____";
                }

            }

            Console.WriteLine(result);

            return result;

        }

        public void WipeBoard()
        {
            for (int row = 0; row < BOARD_LENGTH; row++)
            {
                for (int col = 0; col < BOARD_WIDTH; col++)
                {
                    tile[col, row].content = Symbol.empty;
                }

            }
        }
    }
}
