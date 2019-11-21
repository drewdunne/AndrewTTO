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
            var activePlayer = new Player();
            var board = new Gameboard();
            bool GameOver;
            bool playAgain;
            int turnCount = 0;

            do
            {
                GameOver = false;
                turnCount = 0;
                board = Setup(ref board, ref player1, ref player2); // Create a gameboard!       
                activePlayer = SetActivePlayer(ref activePlayer, player1, player2);

                do
                {
                    Console.Clear();
                    board.Print();
                    TakeTurn(activePlayer, ref board);
                    GameOver = CheckForVictory(ref activePlayer, board);
                    SwapActivePlayer(ref activePlayer, ref player1, ref player2);
                    ++turnCount;
                } while (!GameOver && turnCount < 9);

                Console.WriteLine("\n*** Final Result ***");

                board.Print();

                OutputGameResult(player1, player2, turnCount);
                playAgain = PlayAgainOffer();

            } while (playAgain);

        }


        static Gameboard Setup(ref Gameboard board, ref Player player1, ref Player player2)
        {
            Console.WriteLine("Welcome to Tic Tac Toe!" + "\n");

            if (player1.score == 0 && player2.score == 0)
            {
                Thread.Sleep(1000);
                Gameboard.PrintHelpKey(); 
            }

            else
            {
                PrintScoreboard(player1, player2);
                board.WipeBoard();
            }

            player1.UpdatePlayerVictoryStatus(false);
            player2.UpdatePlayerVictoryStatus(false);

            AssignPlayerTypes(ref player1, ref player2);
            AssignPlayerSymbolsAndTurn(ref player1, ref player2);

            return board;
        }

        static void OutputGameResult(Player player1, Player player2, int turnCount)
        {
            if (player1.victoryStatus)
            {
                Console.WriteLine("\nYou beat an AI that could've been programmed by a nine year old. Feel good about yourself?\n");
            }
            else if (player2.victoryStatus)
            {
                Console.WriteLine("\nThe AI wins. To make matters feel worse, it literally chose its squares at random. How brain-damaged are you?\n");
            }
            else
            {
                Console.WriteLine("\nThe Game Ends in a Tie. A monkey could do better to be honest. -_^\n");
            }
        }

        static void SwapActivePlayer(ref Player activePlayer, ref Player player1, ref Player player2)
        {
            if (player1.turnActive == true)
            {
                player1.turnActive = false;
                player2.turnActive = true;
                activePlayer = player2;
            }
            else if (player2.turnActive == true)
            {
                player1.turnActive = true;
                player2.turnActive = false;
                activePlayer = player1;
            }
            
        }

        static Player SetActivePlayer(ref Player activePlayer, Player player1, Player player2)
        {
            if (player1.turnActive == true && player2.turnActive == false)
            {
                return player1;
            }
            else if (player2.turnActive == true && player1.turnActive == false)
            {
                return player2;
            }
            else
            {
                Console.WriteLine("There is an error with the active turn status Method");
                return activePlayer;
            }
        }

        static bool CheckForVictory(ref Player activePlayer, Gameboard board)
        {
            bool victoryTestResult = false;

            // IF LAST PLAY WAS ON A "MIDDLE" SQUARE, ONLY HORIZONTAL AND VERTICAL VICTORIES ARE POSSIBLE
            if (activePlayer.lastPlay % 2 == 0)
            {
                victoryTestResult = CheckForHorizontalVictory(activePlayer, board);
                if (!victoryTestResult)
                {
                    victoryTestResult = CheckForVerticalVictory(activePlayer, board);
                }

            }

            //IF LAST PLAY WAS ON A "CORNER" SQUARE, OR IN THE CENTER, ALL THREE VICTORY TYPES ARE POSSIBLE
            else if (activePlayer.lastPlay % 2 == 1)
            {
                victoryTestResult = CheckForHorizontalVictory(activePlayer, board);
                if (!victoryTestResult)
                {
                    victoryTestResult = CheckForVerticalVictory(activePlayer, board);
                    if (!victoryTestResult)
                    {
                        victoryTestResult = CheckForDiagonalVictory(activePlayer, board);
                    }
                }

            } 
            
            if (victoryTestResult)
            {
                activePlayer.UpdatePlayerScore();
                activePlayer.UpdatePlayerVictoryStatus(true);
            }

            return victoryTestResult;
            
        }

        static bool CheckForHorizontalVictory(Player activePlayer, Gameboard board)
        {
            int activeTile = activePlayer.lastPlay;
            int x_coord = GetXCoord(activeTile);
            int y_coord = GetYCoord(activeTile);

            if (x_coord == 0) // Left Column
            {
                if (board.tile[x_coord + 1, y_coord].content == activePlayer.PlayersSymbol && board.tile[x_coord + 2, y_coord].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else if (x_coord == 1) // Middle Column
            {
                if (board.tile[x_coord - 1, y_coord].content == activePlayer.PlayersSymbol && board.tile[x_coord + 1, y_coord].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else if (x_coord == 2) // Right Column
            {
                if (board.tile[x_coord - 1, y_coord].content == activePlayer.PlayersSymbol && board.tile[x_coord - 2, y_coord].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else { return false; }

        }

        static bool CheckForVerticalVictory(Player activePlayer, Gameboard board)
        {
            int activeTile = activePlayer.lastPlay;
            int x_coord = GetXCoord(activeTile);
            int y_coord = GetYCoord(activeTile);

            if ( y_coord == 0 )
            {
                if (board.tile[x_coord , y_coord + 1].content == activePlayer.PlayersSymbol && board.tile[x_coord , y_coord + 2].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else if (y_coord == 1)
            {
                if (board.tile[x_coord , y_coord + 1].content == activePlayer.PlayersSymbol && board.tile[x_coord , y_coord - 1].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else if (y_coord == 2)
            {
                if (board.tile[x_coord , y_coord - 1].content == activePlayer.PlayersSymbol && board.tile[x_coord , y_coord - 2].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else { return false; }

        }

        static bool CheckForDiagonalVictory(Player activePlayer, Gameboard board)
        {
            int activeTile = activePlayer.lastPlay;
            int x_coord = GetXCoord(activeTile);
            int y_coord = GetYCoord(activeTile);

            if (x_coord == 0 && y_coord == 0)
            {
                if (board.tile[x_coord + 1, y_coord + 1].content == activePlayer.PlayersSymbol && board.tile[x_coord+ 2, y_coord + 2].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            if (x_coord == 2 && y_coord == 2)
            {
                if (board.tile[x_coord - 1, y_coord - 1].content == activePlayer.PlayersSymbol && board.tile[x_coord - 2, y_coord - 2].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else if (x_coord == 2 && y_coord == 0)
            {
                if (board.tile[x_coord -1 , y_coord + 1].content == activePlayer.PlayersSymbol && board.tile[x_coord - 2, y_coord + 2].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else if (x_coord == 0 && y_coord == 2)
            {
                if (board.tile[x_coord + 1, y_coord - 1].content == activePlayer.PlayersSymbol && board.tile[x_coord + 2, y_coord - 2].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else if (x_coord == 1 && y_coord == 1)
            {
                if (board.tile[x_coord - 1, y_coord - 1].content == activePlayer.PlayersSymbol && board.tile[x_coord + 1, y_coord + 1].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else if (board.tile[x_coord - 1, y_coord + 1].content == activePlayer.PlayersSymbol && board.tile[x_coord + 1, y_coord - 1].content == activePlayer.PlayersSymbol)
                {
                    return true;
                }

                else { return false; }
            }

            else { return false; }

        }
        static void TakeTurn(Player activePlayer, ref Gameboard board)
        {
            
            // Player's Turn
            if (activePlayer.PlayerType == Player.Type.human)
            {
                string prompt = $"Your move {activePlayer.name}!";
                ExecuteHumanTurn(activePlayer, ref board, prompt);
            }
            else if (activePlayer.PlayerType == Player.Type.AI)
            {
                ExecuteAITurn(activePlayer, ref board);
            }


        }

        static void ExecuteHumanTurn(Player activePlayer, ref Gameboard board, string prompt)
        {
            bool isMoveCompleted = false;

            do
            {
                int move = -1;
                do

                {
                    move = ParseInput(prompt);
                } while (move < 0);



                int x_coord = GetXCoord(move);
                int y_coord = GetYCoord(move);

                if (move < 1 || move > 9)
                {
                    Console.WriteLine($"The number {move} is not a valid entry. Please select a number 1-9 or type '/help' to see a helpful diagram.");
                }   
                else if (board.tile[x_coord, y_coord].content == Symbol.X || board.tile[x_coord, y_coord].content == Symbol.O)
                {
                    Console.WriteLine($"Position {move.ToString()} is occupied. Please select another tile. Type '/help' to see a helpful diagram.");
                }
                else if (board.tile[x_coord, y_coord].content == Symbol.empty)
                {
                    isMoveCompleted = true;
                    board.tile[x_coord, y_coord].content = activePlayer.PlayersSymbol;
                    Console.WriteLine($"You Mark an {activePlayer.PlayersSymbol.ToString()} down on position {move.ToString()}.");
                    activePlayer.SetLastPlay(x_coord, y_coord);
                }
            } while (isMoveCompleted == false);


        }

        static void ExecuteAITurn(Player activePlayer, ref Gameboard board)
        {
            int tile_x;
            int tile_y;
           
            DisplayAIThinkingMessage(board);

                do
                {
                    var randomRnd_x = new Random();
                    var randomRnd_y = new Random();
                    tile_x = randomRnd_x.Next(3);
                    tile_y = randomRnd_y.Next(3);

                } while (board.tile[tile_x, tile_y].content != Symbol.empty);

            board.tile[tile_x, tile_y].content = activePlayer.PlayersSymbol;
            Console.Clear();
            board.Print();
            Console.WriteLine($"The AI opts to take position {GetTileID(tile_x, tile_y)} for its turn.");
            activePlayer.SetLastPlay(tile_x, tile_y);
            Thread.Sleep(2000);

        }

        static void DisplayAIThinkingMessage(Gameboard board)
        {
            int emptyTileCount = 0;

            var randomizer = new Random();
            int randomThinkTime = 25 * randomizer.Next(21);
            emptyTileCount = CountEmptyTiles(board);
            int totalThinkTime = randomThinkTime * emptyTileCount;

            Console.WriteLine($"It is the AI's Turn. \n");
            Thread.Sleep(500);

            if (totalThinkTime < 1200)
            {
                Thread.Sleep(totalThinkTime);
            }
            else
            {
                Thread.Sleep(700);
                Console.WriteLine("The AI is thinking... \n");
                Thread.Sleep(totalThinkTime);
            }
        }

        public static int GetXCoord(int Move)
        {
            return ((Move - 1) % 3);
        }

        public static int GetYCoord(int Move)
        {
            return ((Move - 1) / 3);
        }

        public static int GetTileID(int x_coord, int y_coord)
        {
            int ID;

            ID = y_coord * 3 + x_coord + 1;

            return ID;
        }

        static int CountEmptyTiles(Gameboard board)
        {
            int count = 0;

            for (int row = 0; row < Gameboard.BOARD_LENGTH; row++)
            {
                for (int col = 0; col < Gameboard.BOARD_WIDTH; col++)
                {
                    count = board.tile[col, row].content == Symbol.empty ? ++count : count;
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
                Thread.Sleep(750);
                Console.Write("\nThe coin flips and then rattles onto the table.");
                Thread.Sleep(350);
                Console.Write(".");
                Thread.Sleep(450);
                Console.Write(".");
                Thread.Sleep(550);
                Console.Write("..");
                Thread.Sleep(750);
                coinFlipResultMessage(victory: true, coinFlipResult);
                return player1;
            }

            else
            {
                Thread.Sleep(750);
                Console.Write("\nThe coin flips awkwardly and then rattles onto the table.");
                Thread.Sleep(350);
                Console.Write("."); 
                Thread.Sleep(450);
                Console.Write(".");
                Thread.Sleep(550);
                Console.Write("..");
                Thread.Sleep(750);
                coinFlipResultMessage(victory: false, coinFlipResult);
                return player2;
            }

        }


        static CoinSide coinFlipPrompt()
        {

            string prompt = "\nCall it in the air... (h)eads or (t)ails?";
            bool validInput = false;

            do
            {
                string playerGuess = GetPlayerInput(prompt).ToLower();
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
                messageToPrint = (result == CoinSide.heads) ? "\n    It's heads! You go first." : "\n    It's tails! Great guess, you're first!";
            }
            else
            {
                messageToPrint = (result == CoinSide.tails) ? "\n    It's tails, you go second :(" : "\n    It's heads, you go second (sorry!)";
                messageToPrint = (result == CoinSide.error) ? "\n    There was an error with the Coin Flip" : messageToPrint; // if result == CoinSide.error, an error will print. Otherwise, continue as usual.
            }

            Console.WriteLine($"\n {messageToPrint} \n");
            Thread.Sleep(1300);
            Console.WriteLine("Press any key to begin the game!");
            Console.ReadKey();
        }

        static void AssignPlayerTypes(ref Player player1, ref Player player2)
        {
            player1.AssignType(Player.Type.human);
            player2.AssignType(Player.Type.AI);
            AssignPlayerNames(ref player1, ref player2);
        }

        static void AssignPlayerNames(ref Player player1, ref Player player2)
        {
            string prompt;
            if (player1.PlayerType == Player.Type.human && player1.name == "")
            {
                prompt = ("Please Input your name, Player 1");
                player1.AssignName(prompt);
                Console.WriteLine($"\nWelcome to the Game {player1.name}!");
                Thread.Sleep(1000);
            }
            if (player2.PlayerType == Player.Type.human && player2.name == "")
            {
                prompt = "Please Input your name, Player 2";
                player2.AssignName(prompt);
            }
            else if (player2.PlayerType == Player.Type.AI)
            {
                if (player1.score == 0 && player2.score == 0)
                {
                    Console.WriteLine("\n \n... Player 2 will be playing as an AI");
                    Thread.Sleep(1200);
                }
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

        static int ParseInput(string prompt)
        {
            try
            {
                int input = Int32.Parse(GetPlayerInput(prompt));
                return input;
            }

            catch
            {
                Console.WriteLine("Not a valid input. Nice try though! ;) \n");
                Thread.Sleep(500);
                Console.WriteLine("Let's Try this Again. Select a valid position 1-9");
                return -1;
            }
        }

        static void ThrowError(int errorCode, string errorDescription)
        {
            Console.WriteLine("Error Code {errorCode}: {errorDescription}");
        }

        static bool PlayAgainOffer()
        {
            Console.WriteLine("Do you want to play again? (y)es or (n)o?");

            string response;

            do
            {
                response = Console.ReadLine().ToLower();

                if (response == "yes" || response == "y")
                {
                    Console.Clear();
                    Console.Beep(440, 200);
                    Console.Beep(880, 400);
                    return true;
                }
                else if (response == "no" || response == "n")
                {
                    Console.WriteLine("Very Well. Good Game and farewell!");
                    Thread.Sleep(2000);
                    Environment.Exit(0);
                    return false;
                }
                else
                {
                    Console.WriteLine("Sorry, I didn't get that. Try again. Do you want to play another game? Type y or yes for Yes. Or n or no to exit.");
                }


            } while (response != "yes" && response != "y" && response != "no" && response != "n");

            ThrowError(2, "An Error Occurred in the PlayAgainOfferMethod");
            return false;
        }

        static void PrintScoreboard(Player player1, Player player2)
        {
            string p1victory_g = Grammarize("victory", player1.score);
            string p2victory_g = Grammarize("victory", player2.score);
            

            
            Console.WriteLine("*********************************************************************** \n");

            Console.WriteLine($"Player 1 ({player1.PlayerType}) has {player1.score} {p1victory_g}, and Player 2 ({player2.PlayerType}) has {player2.score} {p2victory_g}. \n");

            Console.WriteLine("***********************************************************************");

            
        }

        public static string GetPlayerInput(string prompt)

        { 
            Console.WriteLine(prompt);
            string input = "";
            do

            {
                input = Console.ReadLine();

                if (input == "/help")

                {
                    Gameboard.PrintHelpKey();
                    Thread.Sleep(500);
                    Console.WriteLine("\nNow, " + prompt);
                }

                else

                {
                    return input;
                }

            } while (input == "" || input == "/help");

            ThrowError(3, "Escaped GetPlayerInput Method Loop");
            return input;
        }

        public static string Grammarize(string baseWord, int quantity)
        {
            if (baseWord[baseWord.Length - 1] == 'y' && quantity == 1)
            {
                return baseWord;
            }
            else if (baseWord[baseWord.Length -1] == 'y' && quantity != 1)
            {
                baseWord = baseWord.Substring(0, baseWord.Length - 1) + "ies";
                return baseWord;
            }

            ThrowError(4, "Grammar Error");
            return baseWord;
        }
    }
}
