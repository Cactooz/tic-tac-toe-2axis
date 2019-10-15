using System;

namespace tic_tac_toe_2axis
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] mainBoard = new char[,] {
                {'█', '█', '█' },
                {'█', '█', '█' },
                {'█', '█', '█' }
            };

            Menu(mainBoard);
        }

        //Main menu
        static void Menu(char[,] menuBoard)
        {
            Reset(menuBoard);
            Console.Clear();
            Console.WriteLine("Tic Tac Toe\n");
            Console.WriteLine("To start playing type PLAY\nTo see the tutorial type TUTORIAL");
            string startStatus = "";
            while (startStatus != "play" || startStatus != "tutorial")
            {
                string start = Console.ReadLine();
                startStatus = start.ToLower();
                if (startStatus == "play")
                    Game(menuBoard);
                else if (startStatus == "tutorial")
                    Tutorial(menuBoard);
                else if (startStatus == "exit")
                    Environment.Exit(0);
            }
        }

        //Runs the game
        static void Game(char[,] gameBoard)
        {
            char player = 'X';
            int turn = 0;
            int x = 0;
            int y = 0;
            while (turn < 9) {
                if (turn % 2 == 0)
                    player = 'X';
                else
                    player = 'O';
                turn++;
                Print(gameBoard);
                Console.WriteLine($"\nTurn: {turn}");
                Console.WriteLine($"It's {player}'s turn\n");
                Console.Write("Place: ");
                string location = Console.ReadLine();
                int locationNumber = int.Parse(location);
                Coords(location, ref x, ref y);
                if (locationNumber < 10)
                {
                    if (gameBoard[x, y] != 'O' && gameBoard[x, y] != 'X')
                    {
                        gameBoard[x, y] = player;
                        Print(gameBoard);
                    }
                    else {
                        Console.WriteLine("This place is already taken.");
                        System.Threading.Thread.Sleep(3000); //Wait for 3 seconds
                        turn--;
                    }
                }
                else {
                    Console.WriteLine("You can only choose between 1-9!");
                    System.Threading.Thread.Sleep(3000); //Wait for 3 seconds
                    turn--;
                }
                if (turn >= 5) {
                    CheckWin(gameBoard);
                    if (CheckWin(gameBoard) > 0)
                    {
                        Console.WriteLine($"\nPlayer {player} has won the game!\n");
                        Console.WriteLine("Write MENU to get back to main menu.");
                        Console.WriteLine(CheckWin(gameBoard));
                        string answer = Console.ReadLine();
                        string endAnswer = answer.ToLower();
                        if (endAnswer == "menu")
                            Menu(gameBoard);
                    }
                }
            }
            Console.WriteLine("\nIt's a DRAW...");
            System.Threading.Thread.Sleep(3000); //Wait for 3 seconds
            Menu(gameBoard);
        }

        //Tutorial
        static void Tutorial(char[,] tutorialBoard)
        {
            Console.Clear();
            Console.WriteLine("Welcome to Tic Tac Toe!");
            Console.WriteLine("This is a two player game where you plays X's or O's.");
            Console.WriteLine("This is the game board:\n");
            Console.WriteLine("1 | 2 | 3");
            Console.WriteLine("—————————");
            Console.WriteLine("4 | 5 | 6");
            Console.WriteLine("—————————");
            Console.WriteLine("7 | 8 | 9\n");
            Console.WriteLine("When playing type the number where you want to place your X or O.");
            Console.WriteLine("You win by having a line of 3 characters, either vertical, horizontal or diagonal.\n");
            Console.WriteLine("Done reading? Type DONE to get back to the main menu!");
            string done = "";
            while (done != "done")
            {
                string answer = Console.ReadLine();
                done = answer.ToLower();
                if (done == "done")
                    Menu(tutorialBoard);
            }
        }

        //Prints the gameboard
        static void Print(char[,] printBoard)
        {
            //Clear the console
            Console.Clear();
            //Write out the gameboard
            Console.WriteLine("Tic Tac Toe\n");
            for (int x = 0; x < printBoard.GetLength(0); x++) {
                for (int y = 0; y < printBoard.GetLength(1); y++) {
                    Console.Write($"{printBoard[x, y]}");
                    if (y != 2)
                        Console.Write(" | ");           
                }
                if (x != 2)
                    Console.WriteLine("\n—————————");
            }
        }

        //Convert a number to a coordinate in the array
        static void Coords(string coordLocation, ref int coordX, ref int coordY)
        {
            if (coordLocation == "1") {
                coordX = 0;
                coordY = 0;
            }
            if (coordLocation == "2") {
                coordX = 0;
                coordY = 1;
            }
            if (coordLocation == "3") {
                coordX = 0;
                coordY = 2;
            }
            if (coordLocation == "4") {
                coordX = 1;
                coordY = 0;
            }
            if (coordLocation == "5") {
                coordX = 1;
                coordY = 1;
            }
            if (coordLocation == "6") {
                coordX = 1;
                coordY = 2;
            }
            if (coordLocation == "7") {
                coordX = 2;
                coordY = 0;
            }
            if (coordLocation == "8") {
                coordX = 2;
                coordY = 1;
            }
            if (coordLocation == "9") {
                coordX = 2;
                coordY = 2;
            }
        }

        //Check if someone has won
        static int CheckWin(char[,] resultBoard)
        {
            //Check for top horizontal row
            if (resultBoard[0, 0] != '█' && resultBoard[0, 0] == resultBoard[0, 1] && resultBoard[0, 1] == resultBoard[0, 2] && resultBoard[0, 0] == resultBoard[0, 2])
                return 1;
            //Check for middle horizontal row
            if (resultBoard[1, 0] != '█' && resultBoard[1, 0] == resultBoard[1, 1] && resultBoard[1, 1] == resultBoard[1, 2] && resultBoard[1, 0] == resultBoard[1, 2])
                return 2;
            //Check for bottom horizontal row
            if (resultBoard[2, 0] != '█' && resultBoard[2, 0] == resultBoard[2, 1] && resultBoard[2, 1] == resultBoard[2, 2] && resultBoard[2, 0] == resultBoard[2, 2])
                return 3;
            //Check for left vertical row
            if (resultBoard[0, 0] != '█' && resultBoard[0, 0] == resultBoard[1, 0] && resultBoard[1, 0] == resultBoard[2, 0] && resultBoard[0, 0] == resultBoard[2, 0])
                return 4;
            //Check for middle vertical row
            if (resultBoard[0, 1] != '█' && resultBoard[0, 1] == resultBoard[1, 1] && resultBoard[1, 1] == resultBoard[2, 1] && resultBoard[0, 1] == resultBoard[2, 1])
                return 5;
            //Check for right vertical row
            if (resultBoard[0, 2] != '█' && resultBoard[0, 2] == resultBoard[1, 2] && resultBoard[1, 2] == resultBoard[2, 2] && resultBoard[0, 2] == resultBoard[2, 2])
                return 6;
            //Check for diagonal top left to bottom right \
            if (resultBoard[0, 0] != '█' && resultBoard[0, 0] == resultBoard[1, 1] && resultBoard[1, 1] == resultBoard[2, 2] && resultBoard[0, 0] == resultBoard[2, 2])
                return 7;
            //Check for diagonal top right to bottom left /
            if (resultBoard[0, 2] != '█' && resultBoard[0, 2] == resultBoard[1, 1] && resultBoard[1, 1] == resultBoard[2, 0] && resultBoard[0, 2] == resultBoard[2, 0])
                return 8;
            else
                return 0;
        }

        //Reset board to normal characters
        static void Reset(char[,] resetBoard)
        {
            for (int x = 0; x < resetBoard.GetLength(0); x++) {
                for (int y = 0; y < resetBoard.GetLength(1); y++) {
                    resetBoard[x, y] = '█';
                }
            }
        }
    }
}