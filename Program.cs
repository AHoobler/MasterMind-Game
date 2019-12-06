using System;
using System.Linq;


namespace MasterMinds
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to MasterMind!");
            Console.WriteLine("Please Enter a 4 Digit number using only numbers 1-6");

            Random rndNum = new Random();
            int[] newInt = new int[4];

            while (newInt.Distinct().Count() != 4)
            {
                for (int x = 0; x < 4; x++)
                {
                    newInt[x] = rndNum.Next(1, 7);
                }
            }

            int attempts = 0;
            while (true)
            {
                string userInput = Console.ReadLine();
                attempts++;
                int[] userNumber = userInput.Select(v => v - '0').ToArray();
                int correctNumber = 0;
                int correctPosition = 0;


                if (userNumber.Any(i => i > 6) || userNumber.Length != 4)
                {
                    Console.WriteLine("Please only enter a 4 digit number using numbers 1-6. Please try again.");
                    continue;
                }

                for (int i = 0; i < 4; i++)
                {
                    if (newInt[i] == userNumber[i])
                    {
                        correctPosition++;
                        correctNumber++;
                        Console.Write("+");
                    }
                    else if (newInt.Contains(userNumber[i]))
                    {
                        correctNumber++;
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(" ");
                    }
                }

                if (correctPosition == 4)
                {
                    Console.WriteLine(" You've won the game! It took you " + attempts + " guesses");
                    Console.ReadLine();
                    break;
                }

                if (attempts.Equals(10))
                {
                    Console.WriteLine(" You have reached 10 attempts. You lose.");
                    Console.ReadLine();
                    break;
                }

                Console.Write(" " + correctNumber + " correct, ");
                Console.WriteLine(correctPosition + " in the correct position. Try Again.");
            }
        }
    }
}
