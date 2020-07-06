using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        public static void Main(string[] args)
        {
            
            // stage 1
            // Console.WriteLine("X O X");
            // Console.WriteLine("O X O");
            // Console.WriteLine("X X O");


            // stage 2
            Console.WriteLine("Enter cells: ");
            string userInput = Console.ReadLine();
            char[] user1dInput = userInput.ToCharArray();

            bool gameEnd = false;
            string gameMessage = "";
            char[,] user2dInput = new char[3,3];
            int index = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    user2dInput[i, j] = user1dInput[index];
                    index++;
                }
            }

            PrintUserArray(user2dInput);
            Console.WriteLine("Enter the Coordinates: ");

            // Taking coordinates from user
            //string coord = Console.ReadLine();
            //char[] coorCharArray = coord.ToCharArray();
            //int[] coordIntArray = Array.ConvertAll(coorCharArray, c => (int)Char.GetNumericValue(c));
            try
            {
                user2dInput = TakeUserCoord(user2dInput);
            }
 
            catch (Exception occupiedEx)
            {
                Console.WriteLine("{0}", occupiedEx.Message);
                TakeUserCoord(user2dInput);
            }

            //user2dInput[(3 - coordIntArray[1]), (coordIntArray[0] - 1)] = 'X';
            PrintUserArray(user2dInput);

            // if (CheckWin(user2dInput, ref gameEnd, ref gameMessage))
           // {
           //     Console.WriteLine("{0}",gameMessage);
           // }
            Console.ReadLine();
        }

        // Method for taking user input for the Coordinates
        private static char[,]  TakeUserCoord(char[,] grid2DArray)
        {
            string coord = Console.ReadLine();
            char[] coordCharArray = coord.ToCharArray();
            int[] coordIntArray = Array.ConvertAll(coordCharArray, c => (int)Char.GetNumericValue(c));

            char[,] gridInput = CheckUserCoord(coordIntArray, grid2DArray);
            return gridInput;
        }

        // Method for checking the  user input for the coordinates
        public static char[,]  CheckUserCoord(int[] userCoord, char[,] gridInput)
        {
            if (gridInput[(3 - userCoord[1]), (userCoord[0] - 1)] == 'X' || gridInput[(3 - userCoord[1]), (userCoord[0] - 1)] == 'O')
            {
                Exception occupiedEx = new Exception("This cell is occupied! Choose another one!");
                throw occupiedEx;
            }
            else
            {
                gridInput[(3 - userCoord[1]), (userCoord[0] - 1)] = 'X';
            }
            return gridInput;
        }

        private static char PrintUserArray(char [,] userInput)
        {

            Console.WriteLine("---------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("|");
                Console.Write(" ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(userInput[i, j]);
                    Console.Write(" ");
                }
                Console.Write(" ");
                Console.Write("|");
                Console.Write("\n");
            }
            Console.WriteLine("---------");
            return '0';
        }

        private static bool CheckWin(char[,] input, ref bool gameEnd , ref string gameMessage)
        {
            // var to check the difference between 'X' and 'O' count in grid
            int charCountDiff = 0;
            charCountDiff = CharCounter(input, 'X') - CharCounter(input, 'O');

            if ((IsWin(input,'X') && IsWin(input,'O'))|| Math.Abs(charCountDiff) >= 2)
            {
                gameEnd = true;
                gameMessage = "Impossible";
            }
            else if (IsWin(input,'X'))
            {
                gameEnd = true;
                gameMessage = "X Wins!";
            }
            else if (IsWin(input,'O'))
            {
                gameEnd = true;
                gameMessage = "O Wins!";
            }
            else if (IsDraw(input))
            {
                gameEnd = true;
                gameMessage = "Draw!";
            }
            else if (!IsWin(input, 'X') && !IsWin(input, 'O') && !IsDraw(input))
            {
                gameEnd = false;
                gameMessage = " Game not finished";
            }

            return gameEnd;
        }

        // method for wining condition
        static bool IsWin(char[,] userInput, char sign)
        {
            // row win case
            return (userInput[0, 0] == sign && userInput[0, 1] == sign && userInput[0, 2] == sign
                    || userInput[1, 0] == sign && userInput[1, 1] == sign && userInput[1, 2] == sign
                    || userInput[2, 0] == sign && userInput[2, 1] == sign && userInput[2, 2] == sign
                    // column win case
                    || userInput[0, 0] == sign && userInput[1, 0] == sign && userInput[2, 0] == sign
                    || userInput[0, 1] == sign && userInput[1, 1] == sign && userInput[2, 1] == sign
                    || userInput[0, 2] == sign && userInput[1, 2] == sign && userInput[2, 2] == sign
                    // diagonal win case
                    || userInput[0, 0] == sign && userInput[1, 1] == sign && userInput[2, 2] == sign
                    || userInput[0, 2] == sign && userInput[1, 1] == sign && userInput[2, 0] == sign);
        }

        // method to check the draw condition
        static bool IsDraw(char[,] userInput)
        {
            // var for the space in the grid
            bool isSpace = false;
            // var to find is there draw in the game or not
            bool isDraw = false;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((userInput[i, j] == '_'|| userInput[i, j] == ' '))
                    {
                        isSpace = true;
                    }
                }
            }

            if (isSpace == false && !IsWin(userInput, 'X') && !IsWin(userInput, 'O'))
            {
                isDraw = true;
            }

            return isDraw;
        }

        static int CharCounter(char[,] userArray, char sign)
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((userArray[i, j] == sign))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
