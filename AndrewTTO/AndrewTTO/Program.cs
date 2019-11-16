using System;

namespace AndrewTTO
{
    class Program
    {
        static void Main(string[] args)
        {
            // Provide a welcome message
            Console.WriteLine("Welcome to Tic Tac Toe!" + "\n" + "\n");

            // Print the empty board
            Gameboard board = Setup();
            
            //Creates a variable to determine which player will go first
            var firstTurn = new Random();

            // Returns which player goes first by running 'Next' method within the Random class. Generates a random number between 0 and 1.
            int PlayerTurn = (firstTurn.Next(1));

            TakeTurn(ref PlayerTurn, ref board);

            board.Print();
            

            //Pause the game
            Console.ReadLine();
        }


        static Gameboard Setup()
        {
            // Declares a new Gameboard named 'board' which is made of 9 Tile objects
            var board = new Gameboard();

            // Prints the Gameboard, as well as the valued
            board.Print();
           
            return board;
        }

        static void TakeTurn(ref int PlayerTurn, ref Gameboard board)
        {
            
            if (PlayerTurn == 0)
            {
                int tile_x;
                int tile_y;
                do
                {
                    var randomRnd_x = new Random();
                    var randomRnd_y = new Random();
                    tile_x = randomRnd_x.Next(2);
                    tile_y = randomRnd_y.Next(2);


                } while (board.tile[tile_x, tile_y].content != MoveType.empty);

                board.tile[tile_x, tile_y].content = MoveType.O;
            }

            else if (PlayerTurn == 1)
            {
                Console.WriteLine("Your move!");
                Console.ReadLine();

                // TASK: Need to interpret and convert readline into an actual move.
            }

            else
            {
                Console.WriteLine("ERROR: Current Player Turn is an invalid value. Please Contact Customer Support.");
            }

        }

        void Update()
        {

        }

    }

}
