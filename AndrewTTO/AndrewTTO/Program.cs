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
            Setup();




            //Pause the game
            Console.ReadLine();
        }


        static void Setup()
        {
            Gameboard board = new Gameboard();
            board.Print();

        }

        void Input()
        {

        }

        void Update()
        {

        }

    }

}
