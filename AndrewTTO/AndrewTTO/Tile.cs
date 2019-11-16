using System;
using System.Collections.Generic;
using System.Text;

namespace AndrewTTO
{

    public enum ContentType {empty, X, O };

    class Tile
    {
        
        public ContentType contents;

        public Tile()
        {
              contents = ContentType.empty;
        }
        public override string ToString()
        {
            if (this.contents == ContentType.empty)
            {
                return "     ";
            }
            if (this.contents == ContentType.X)
            {
                return "  X  ";

            }
            if (this.contents == ContentType.O)
            {
                return "  O  ";
            }
            else
            { return "#####"; } // ideally I would have this throw an exception I think, but I'll need to address this later.

        }
    }

    
}
