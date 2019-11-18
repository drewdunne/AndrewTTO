using System;
using System.Collections.Generic;
using System.Text;


namespace AndrewTTO
{

    class Player
    {
        public enum Type { human, AI };

        private Symbol playersSymbol { get; set; }
        private Type playerType { get; set; }
        public Symbol PlayersSymbol { get; set; }
        public Type PlayerType { get; set; }

        public string name { get; set; }
        public bool turnActive { get; set; }

        public int score {get; set;}

        public int lastPlay { get; set; }
        public bool victoryStatus { get; set; }


        public Player()
        {
            score = 0;
            name = "";
        }

        public void AssignSymbol(Symbol assignedSymbol)
        {
            PlayersSymbol = assignedSymbol;
        }

        public void AssignType(Type assignedType)
        {
            PlayerType = assignedType;
        }

        public void AssignName(string prompt)
        {
            name = Program.GetPlayerInput(prompt);
        }

        public void SetTurnActiveStatus(bool status)
        {
            turnActive = status;
        }

        public void SetLastPlay(int x_coord, int y_coord)
        {
            lastPlay = Program.GetTileID(x_coord, y_coord);
        }

        public void UpdatePlayerScore()
        {
            ++score;
        }

        public void UpdatePlayerVictoryStatus(bool result)
        {
            victoryStatus = result;
        }
    }
}
