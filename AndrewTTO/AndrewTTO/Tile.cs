using System;
using System.Collections.Generic;
using System.Text;

namespace AndrewTTO
{

    public enum MoveType {empty, X, O };

    class Tile
    {
        
        public MoveType content;

        public Tile()
        {
              content = MoveType.empty;
        }
        public override string ToString()
        {
            if (this.content == MoveType.empty)
           {
                return "     ";
            }
            if (this.content == MoveType.X)
            {
                return "  X  ";

            }
            if (this.content == MoveType.O)
            {
                return "  O  ";
            }
            else
            { return "#####"; } // ideally I would have this throw an exception I think, but I'll need to address this later.

        }
    }

    
}
