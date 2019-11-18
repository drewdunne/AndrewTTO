using System;
using System.Threading;

namespace AndrewTTO
{
    enum CurrentTurn { player1, player2 };
    enum CoinSide { heads, tails, error};

    class Program
    {
        static void Main(string[] args)
        {

            var player1 = new Player();
            var player2 = new Player();
            bool GameOver = false;

            int turnCount = 0;

            Gameboard board = Setup(ref player1, ref player2); // Create a gameboard!
            Player activePlayer = CoinFlipContest(player1, player2); // Who will go first?

            do
            {
                PrintBoard(board);
                TakeTurn(activePlayer, ref board);
                SwapActivePlayer(ref activePlayer, player1, player2);
                ++turnCount;
            } while (!GameOver);



            //Pause the game
            Console.ReadLine();
        }


        static Gameboard Setup(ref Player player1, ref Player player2)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!" + "\n" + "\n");

            var board = new Gameboard();

            AssignPlayerTypes(ref player1, ref player2);
            AssignPlayerSymbolsAndTurn(ref player1, ref player2);

            return board;
        }

        static void TakeTurn(Player activePlayer, ref Gameboard board)
        {

            // Player's Turn
            if (activePlayer.PlayerType == Player.Type.human)
            {
                Console.WriteLine($"Your move {activePlayer.name}!");
                ExecuteHumanTurn(activePlayer, ref board);
            }

            // AI's Turn
            else if (activePlayer.PlayerType == Player.Type.AI)
            {
                DisplayAIThinkingMessage(board);

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

        static void PrintBoard(Gameboard boardToPrint)
        {
            boardToPrint.Print();
        }

        static void SwapActivePlayer(ref Player activePlayer, Player player1, Player player2)
        {
            activePlayer = (activePlayer == player1) ? player2 : player1;
            activePlayer = (activePlayer == player2) ? player1 : player2;
        }
        static void ExecuteHumanTurn(Player activePlayer, ref Gameboard board)
        {
            bool isMoveCompleted = false;

            do
            {
                int move = Convert.ToInt32(Console.ReadLine());

                int x_coord = GetXCoord(move);
                int y_coord = GetYCoord(move);

                if (board.tile[x_coord, y_coord].content == Symbol.empty)
                {
                    isMoveCompleted = true;
                    board.tile[x_coord, y_coord].content = activePlayer.PlayersSymbol;
                    Console.WriteLine($"You Mark an {activePlayer.PlayersSymbol.ToString()} down on position {move.ToString()}.");
                }
                else if (board.tile[x_coord, y_coord].content == Symbol.X || board.tile[x_coord, y_coord].content == Symbol.O)
                {
                    Console.WriteLine($"Position {move.ToString()} is occupied. Please select another tile. Type '/help' to see a helpful diagram (NOT YET AVAILABLE)");
                }
                else if (move < 1 || move > 9)
                {
                    Console.WriteLine($"The number {move} is not a valid entry. Please select a number 1-9 or type '/help' to see a helpful diagram.");
                }
            } while (isMoveCompleted == false);
        }

        static void DisplayAIThinkingMessage(Gameboard board)
        {
            int emptyTileCount = 0;

            var randomizer = new Random();
            int randomThinkTime = 25 * randomizer.Next(20);
            emptyTileCount = CountEmptyTiles(board);
            int totalThinkTime = randomThinkTime * emptyTileCount;

            Console.WriteLine($"It is the AI's Turn.");
            Thread.Sleep(500);

            if (totalThinkTime < 1200)
            {
                Thread.Sleep(totalThinkTime);
            }
            else
            {
                Console.WriteLine("The AI is thinking...");
                Thread.Sleep(totalThinkTime);
            }
        }

        static int GetXCoord(int Move)
        {
            return ((Move - 1) % 3);
        }

        static int GetYCoord(int Move)
        {
            return ((Move - 1) / 3);
        }

        static int CountEmptyTiles(Gameboard board)
        {
            int count = 0;

            for (int row = 0; row < Gameboard.BOARD_LENGTH; row++)
            {
                for (int col = 0; col < Gameboard.BOARD_WIDTH; col++)
                {
                    count = board.tile[col, row].content == Symbol.empty ? count++ : count;
                }

            }

            return count;
        }
        static Player CoinFlipContest(Player player1, Player player2)
        {

            CoinSide playerGuess = coinFlipPrompt();
            CoinSide coinFlipResult = FlipACoin();

            if (playerGuess == coinFlipResult)
            {
                coinFlipResultMessage(victory: true, coinFlipResult);
                return player1;
            }

            else
            {
                coinFlipResultMessage(victory: false, coinFlipResult);
                return player2;
            }

        }

        static CoinSide coinFlipPrompt()
        {

            Console.WriteLine("Call it in the air... (h)eads or (t)ails?");
            bool validInput = false;

            do
            {
                string playerGuess = Console.ReadLine().ToLower();
                if (playerGuess == "heads" || playerGuess == "h")
                {
                    return CoinSide.heads;
                }
                else if (playerGuess == "tails" || playerGuess == "t")
                {
                    return CoinSide.tails;
                }
                else
                {
                    Console.WriteLine("That is not a valid guess, try again!");
                }
            } while (validInput == false);

            return CoinSide.error;
        }

        static CoinSide FlipACoin()
        {
            var randomNumber = new Random();
            CoinSide result = randomNumber.Next(2) == 0 ? CoinSide.heads : CoinSide.tails;
            return result;
        }

        static void coinFlipResultMessage(bool victory, CoinSide result)
        {

            string messageToPrint;

            if (victory)
            {
                messageToPrint = (result == CoinSide.heads) ? "It's heads! You go first." : "It's tails! Great guess, you're first.";
            }
            else
            {
                messageToPrint = (result == CoinSide.tails) ? "It's tails, you go second :(" : "It's heads, you go second (sorry!)";
                messageToPrint = (result == CoinSide.error) ? "There was an error with the Coin Flip" : messageToPrint; // if result == CoinSide.error, an error will print. Otherwise, continue as usual.
            }

        }

        static void AssignPlayerTypes(ref Player player1, ref Player player2)
        {
            player1.AssignType(Player.Type.human);
            player2.AssignType(Player.Type.AI);
            AssignPlayerNames(ref player1, ref player2);
        }

        static void AssignPlayerNames(ref Player player1, ref Player player2)
        {
            if (player1.PlayerType == Player.Type.human)
            {
                Console.WriteLine("Please Input your name, Player 1");
                player1.AssignName();
                Console.WriteLine($"Welcome to the Game {player1.name}!");
                Thread.Sleep(1000);
            }
            if (player2.PlayerType == Player.Type.human)
            {
                Console.WriteLine("Please Input your name, Player 2");
                player2.AssignName();
            }
            else if (player2.PlayerType == Player.Type.AI)
            {
                Console.WriteLine("Player 2 will be playing as an AI");
                Thread.Sleep(1000);
            }

        }

        static void AssignPlayerSymbolsAndTurn(ref Player player1, ref Player player2)
        {
            Player winningPlayer;
            winningPlayer = CoinFlipContest(player1, player2);

            if (player1 == winningPlayer)
            {
                player1.AssignSymbol(Symbol.X);
                player2.AssignSymbol(Symbol.O);
                player1.SetTurnActiveStatus(true);
                player2.SetTurnActiveStatus(false);
            }
            else if (player2 == winningPlayer)
            {
                player1.AssignSymbol(Symbol.O);
                player2.AssignSymbol(Symbol.X);
                player1.SetTurnActiveStatus(false);
                player2.SetTurnActiveStatus(true);
            }
        }

    }
}
