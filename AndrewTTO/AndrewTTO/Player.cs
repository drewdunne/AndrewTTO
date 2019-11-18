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


        public Player()
        {          
        }

        public void AssignSymbol(Symbol assignedSymbol)
        {
            PlayersSymbol = assignedSymbol;
        }

        public void AssignType(Type assignedType)
        {
            PlayerType = assignedType;
        }

        public void AssignName()
        {
            Console.WriteLine("Please Input your name!");
            name = Console.ReadLine();
        }

        public void SetTurnActiveStatus(bool status)
        {
            turnActive = status;
        }
    }
}
