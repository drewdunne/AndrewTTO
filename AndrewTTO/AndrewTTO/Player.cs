using System;
using System.Collections.Generic;
using System.Text;

namespace AndrewTTO
{

    class Player
    {
        enum Type { human, AI };

        private Symbol playersSymbol { get; set; }
        public Symbol PlayersSymbol { get; set; }


        public Player(Symbol assignedSymbol)
        {
            assignedSymbol = PlayersSymbol;
            playersSymbol = PlayersSymbol;
        }
    }
}
