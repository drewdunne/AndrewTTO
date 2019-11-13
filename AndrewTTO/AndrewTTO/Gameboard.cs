using System;
using System.Collections.Generic;
using System.Text;

namespace AndrewTTO
{
    class Gameboard
    {
        public Gameboard()
        {

        }

        public override string ToString()
        {
            return "Name: " + name + " balance: " + balance;
        }

        public void Print(Gameboard board)
        {
            Console.WriteLine(board.ToString());
        }
    }
}
