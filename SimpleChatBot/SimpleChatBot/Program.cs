using System;

namespace SimpleChatBot
{
    class Program
    {
        static void Main(string[] args)
        {
            Greet();
            GuessAge();
            NumberCounter();
            Test();
            MathTest();
        }

        static void Greet()
        {
            string botName = "botscope";
            int birthYear = 2020;
            string botCreator = "Diwash Shrestha";
            Console.WriteLine("Hello! My name is {0}.",botName);
            Console.WriteLine("I was created in {0} by {1}.",birthYear,botCreator);
            Console.WriteLine("What is your name?");
            string botUser = Console.ReadLine();
            Console.WriteLine("What a great name you have, {0}.",botUser);
        }

        static void GuessAge()
        {
            Console.WriteLine("Let me guess your age.");
            Console.WriteLine("Say me remainders of dividing your age by 3, 5 and 7.");
            int rem3 = Convert.ToInt32(Console.Read());
            int rem5 = Convert.ToInt32(Console.Read());
            int rem7 = Convert.ToInt32(Console.Read());
            int age = (rem3 * 70 + rem5 * 21 + rem7 * 15) % 105;
            Console.WriteLine("Your age is {0}. That's a good time to start programming!",age);
            Console.ReadLine();

        }

        static void NumberCounter()
        {
            Console.WriteLine("Now I will prove to you that I can count to any number you want.");
            int countNumber = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i <= countNumber; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void Test()
        {
            Console.WriteLine("Let's test your Programming Knowledge.");
            Console.WriteLine("Why do we use methods?");
            Console.WriteLine("1. To repeat a statement multiple times.");
            Console.WriteLine("2. To decompose a program into several small subroutines.");
            Console.WriteLine("3. To determine the execution time of a program.");
            Console.WriteLine("4. To interrupt the execution of a program.");


            int answer = 0;
            do
            {
                Console.WriteLine("Enter Your Answer: ");
                answer = Convert.ToInt32(Console.ReadLine());

                if (answer != 2)
                {
                    Console.WriteLine("Wrong Answer, Please Try again!");
                }
                else
                {
                    Console.WriteLine("Congratulations, Correct Answer.");
                    Console.WriteLine("Have a Great Day");
                }
            } while (answer != 2);
        }

        static void MathTest()
        {
            Console.WriteLine("");
            Console.WriteLine("Lets Test Your Mathematical Knowledge.");
            Random r = new  Random();
            int randomNum = r.Next(1,1100);

            string trueTruth; 

            if (randomNum % 2 == 0)
            {
                 trueTruth = "even";
            }
            else
            {
                 trueTruth = "odd";
            }
            Console.WriteLine("Is {0} Odd or Even?(Odd| Even)",randomNum);
            string randomTruth = Console.ReadLine()?.ToLower();

            Console.WriteLine(
                trueTruth == randomTruth ? "Correct Answer, {0} is {1} number." : "Wrong Answer.{0} is {1} number.",
                randomNum, trueTruth);
            Console.WriteLine("Have a Great day!");
        }
    }
}
