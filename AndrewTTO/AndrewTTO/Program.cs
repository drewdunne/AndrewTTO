using System;
using System.Threading;

namespace AndrewTTO
{
    enum currentTurn { player1, player2 };

    class Program
    {
        static void Main(string[] args)
        {
            bool GameOver = false;
            int turnCount = 0;
            bool playerTurn = false;

            Gameboard board = Setup(ref playerTurn); // Create a gameboard!



            while (!GameOver)
            {
                board.Print();
                TakeTurn(ref playerTurn, ref board);
                GameOver = EvaluateGameOver(playerTurn, board);
                playerTurn = !playerTurn;
                ++turnCount;
            }

            

            //Pause the game
            Console.ReadLine();
        }


        static Gameboard Setup(ref bool playerTurn)
        {
            // Declares a new Gameboard named 'board' which is made of 9 Tile objects
            var board = new Gameboard();

            Console.WriteLine("Welcome to Tic Tac Toe!" + "\n" + "\n"); // Provide a welcome message
            playerTurn = FlipACoin(); // Player guesses heads or tails

            return board;
        }

        static void TakeTurn(ref bool playerTurn, ref Gameboard board)
        {

             // Player's Turn
            if (playerTurn)
            {
                Console.WriteLine("Your move!");
                bool isMoveCompleted = false;

                // Execute Player's move
                do
                {
                    string issuedCommand = Console.ReadLine();

                    // Interpret player's command into a game move.
                    switch (issuedCommand)
                    {
                        case "1":
                            if (board.tile[0, 0].content == Symbol.empty)
                            { board.tile[0, 0].content = Symbol.X; isMoveCompleted = true; }
                            else { Console.WriteLine("Position 1 is occupied, please select another position"); }
                            break;
                        case "2":
                            if (board.tile[1, 0].content == Symbol.empty)
                            { board.tile[1, 0].content = Symbol.X; isMoveCompleted = true; }
                            else { Console.WriteLine("Position 2 is occupied, please select another position"); }
                            break;
                        case "3":
                            if (board.tile[2, 0].content == Symbol.empty)
                            { board.tile[2, 0].content = Symbol.X; isMoveCompleted = true; }
                            else { Console.WriteLine("Position 3 is occupied, please select another position"); }
                            break;
                        case "4":
                            if (board.tile[0, 1].content == Symbol.empty)
                            { board.tile[0, 1].content = Symbol.X; isMoveCompleted = true; }
                            else { Console.WriteLine("Position 4 is occupied, please select another position"); }
                            break;
                        case "5":
                            if (board.tile[1, 1].content == Symbol.empty)
                            { board.tile[1, 1].content = Symbol.X; isMoveCompleted = true; }
                            else { Console.WriteLine("Position 5 is occupied, please select another position"); }
                            break;
                        case "6":
                            if (board.tile[2, 1].content == Symbol.empty)
                            { board.tile[2, 1].content = Symbol.X; isMoveCompleted = true; }
                            else { Console.WriteLine("Position 6 is occupied, please select another position"); }
                            break;
                        case "7":
                            if (board.tile[0, 2].content == Symbol.empty)
                            { board.tile[0, 2].content = Symbol.X; isMoveCompleted = true;  }
                            else { Console.WriteLine("Position 7 is occupied, please select another position"); }
                            break;
                        case "8":
                            if (board.tile[1, 2].content == Symbol.empty)
                            { board.tile[1, 2].content = Symbol.X; isMoveCompleted = true; }
                            else { Console.WriteLine("Position 8 is occupied, please select another position"); }
                            break;
                        case "9":
                            if (board.tile[2, 2].content == Symbol.empty)
                            { board.tile[2, 2].content = Symbol.X; isMoveCompleted = true; }
                            else { Console.WriteLine("Position 9 is occupied, please select another position"); }
                            break;
                        default:
                            Console.WriteLine("Invalid Command");
                            break;
                    }
                    
                } while (isMoveCompleted != true);

                
             }

            // AI's Turn
            else if (!playerTurn)
            {
                Console.WriteLine("It's the AI's turn. Thinking...");
                Thread.Sleep(2000);
                int tile_x;
                int tile_y;
                do
                {
                    var randomRnd_x = new Random();
                    var randomRnd_y = new Random();
                    tile_x = randomRnd_x.Next(2);
                    tile_y = randomRnd_y.Next(2);


                } while (board.tile[tile_x, tile_y].content != Symbol.empty);

                board.tile[tile_x, tile_y].content = Symbol.O;
            }

            // Error Catch
            else
            {
                Console.WriteLine("ERROR: Current Player Turn is an invalid value. Please Contact Customer Support.");
            }

        }

        void Update()
        {

        }

        static bool FlipACoin()
        {
            Console.WriteLine("Call it in the air... (h)eads or (t)ails?");
            string playerGuess = Console.ReadLine().ToLower();
            bool wasPlayerCorrect;
            var coinFlip = new Random();
            bool coinLandsHeads = coinFlip.Next(2) == 0 ? true : false;
            string coinFlipResultMessage = "";

            do
            {

                if (playerGuess == "heads" || playerGuess == "h")
                {
                    coinFlipResultMessage = coinLandsHeads ? "It's heads! You go first." : "It's tails, you go second :(";
                    Console.WriteLine(coinFlipResultMessage);
                    return coinLandsHeads ? true : false;
                }
                if (playerGuess == "tails" || playerGuess == "t")
                {

                    coinFlipResultMessage = coinLandsHeads ? "It's heads, you go second (sorry!)" : "It's tails! Great guess, you're first.";
                    Console.WriteLine(coinFlipResultMessage);
                    return coinLandsHeads ? false : true;
                }
                else
                {
                    Console.WriteLine("That is not a valid guess, try again!");
                }
            } while (coinFlipResultMessage == "");

            Console.WriteLine("A Critical Error has Occured in Method FlipACoin(). Please make your way to the nearest fire escape in an orderly fashion.");

            return false;
        }

        static bool EvaluateGameOver(playerTurn, Gameboard board)
        {
            bool isGameOver;

            // Evaluate Horizontal Victories
            for (int row = 0; row < Gameboard.BOARD_LENGTH; ++row)
            {
                if board.tile[row,]
            }
        }

    }

}
