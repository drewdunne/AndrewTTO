using System;
using System.Collections.Generic;
using System.Text;

namespace AndrewTTO
{
    class Tile
    {
        public enum ContentType { empty, X, O };
        
        public ContentType contents;

        public Tile()
        {
            contents = ContentType.empty;
        }
        public override string ToString()
        {
            if (contents == ContentType.empty)
            {
                return "     ";
            }
            if (contents == ContentType.X)
            {
                return "  X  ";

            }
            if (contents == ContentType.O)
            {
                return "  O  ";
            }
            else
            { return "#####"; } // ideally I would have this throw an exception I think, but I'll need to address this later.

        }
    }

    
}
