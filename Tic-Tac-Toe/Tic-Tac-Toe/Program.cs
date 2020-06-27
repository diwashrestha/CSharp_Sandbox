using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        public static void Main(string[] args)
        {
            // Console.WriteLine("X O X");
            // Console.WriteLine("O X O");
            // Console.WriteLine("X X O");


            Console.WriteLine("Enter cells:");
            string userInput = Console.ReadLine();
            Console.WriteLine(userInput);
            char[] user1dInput = userInput.ToCharArray();

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

            Console.WriteLine("---------");
            for (int i = 0; i < 3; i++)
            {
                Console.Write("|");
                Console.Write(" ");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(user2dInput[i,j]);
                    Console.Write(" ");
                }
                Console.Write(" ");
                Console.Write("|");
                Console.Write("\n");
            }
            Console.WriteLine("---------");

            GameCases(user2dInput);
            CheckWin(user2dInput);
            Console.ReadLine();
        }

        public static void GameCases(char[,] userInput)
        {
            string gameResult = "";
            var gameSign = new[] {'X', 'O', '_'};

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((userInput[i,j] == gameSign[2]))
                    {
                        gameResult = "Game not finished";
                    }
                }
            }
            Console.WriteLine(gameResult);
            return;
        }


        private static bool CheckWin(char[,] input)
        {
            if (IsWin(input,'X'))
            {
                Console.WriteLine("X WINS!");
                
            }
            else if (IsWin(input,'O'))
            {
                Console.WriteLine("O WINS!");
            }
            return true;

        }


        static bool IsWin(char[,] userInput, char sign)
        {
            // row win case
            return (userInput[0, 0] == sign && userInput[0, 1] == sign && userInput[0, 2] == sign
                    || userInput[1, 0] == sign && userInput[1, 1] == sign && userInput[1, 2] == sign
                    || userInput[2, 0] == sign && userInput[2, 1] == sign && userInput[2, 2] == sign);

        }
    }
}
