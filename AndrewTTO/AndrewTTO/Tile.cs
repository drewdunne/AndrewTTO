using System;
using System.Collections.Generic;
using System.Text;

namespace AndrewTTO
{

    public enum Symbol {empty, X, O };

    class Tile
    {
        public int x_cord;
        public int y_cord;
        public int ID;
        
        public Symbol content;

        public Tile()
        {
              content = Symbol.empty;
        }
        public override string ToString()
        {
            if (this.content == Symbol.empty)
           {
                return " ";
            }
            if (this.content == Symbol.X)
            {
                return "X";

            }
            if (this.content == Symbol.O)
            {
                return "O";
            }
            else
            { return "#"; } // ideally I would have this throw an exception I think, but I'll need to address this later.

        }
    }

    
}
