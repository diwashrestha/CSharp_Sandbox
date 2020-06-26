using System;

namespace Tic_Tac_Toe
{
    class Program
    {
        static void Main(string[] args)
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

         


            Console.ReadLine();
        }

        void GameCases(char[,] userInput)
        {
            if(())
        }
    }
}
