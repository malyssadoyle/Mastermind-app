using System;
using System.Linq;

namespace MastermindExercise
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Try to guess the 4-digit number correctly in under 10 tries.");
            Console.WriteLine();
            Console.WriteLine("HINTS:");
            Console.WriteLine("- A minus (-) sign will be printed for every digit that is correct but in the wrong position.");
            Console.WriteLine("- A plus (+) sign will be printed for every digit that is both correct and in the correct position.");
            Console.WriteLine("- Nothing (_) will be printed for incorrect digits.");
            Console.WriteLine();

            int randomNum = GenerateRandomNumber(1, 6);

            int allowedGuesses = 11;
            int numberOfGuesses = 1;
            
            while (true)
            {
                int guessNum = GetGuess(numberOfGuesses);
                numberOfGuesses++;
                if (randomNum == guessNum)
                {
                    Console.WriteLine();
                    Console.WriteLine("You win - your guess was correct!");
                    Console.ReadKey();
                    break;
                    
                }
                if (numberOfGuesses == allowedGuesses)
                {
                    Console.WriteLine();
                    Console.WriteLine($"You lose - the correct number was {randomNum}.");
                    Console.ReadKey();
                    break;
                }

                Console.WriteLine();
                Console.WriteLine($"HINT: {ReturnCode(randomNum, guessNum)}");
            }
        }

        private static bool ValidateGuess(string guessNum)
        {
            if (guessNum.Length != 4)
            {
                return false;
            }

            foreach (var g in guessNum)
            {
                if (char.IsDigit(g)) continue;
                return false;
            }

            return true;
        }

        private static int GetGuess(int numberOfGuesses)
        {
            Console.WriteLine(numberOfGuesses > 1
                ? $"Please guess again. This will be guess number {numberOfGuesses}."
                : "Please enter a 4-digit number.");

           

            string guess = Console.ReadLine();
            while (!ValidateGuess(guess))
            {
                Console.WriteLine();
                Console.WriteLine($"Invalid guess. Please enter a 4-digit number.");
                guess = Console.ReadLine();
            }
            return Convert.ToInt32(guess);
        }

        private static int GenerateRandomNumber(int min, int max)
        {
            Random random = new Random();
            string randomNumber = random.Next(min, max).ToString();
            randomNumber += random.Next(min, max).ToString();
            randomNumber += random.Next(min, max).ToString();
            randomNumber += random.Next(min, max).ToString();
            return Convert.ToInt32(randomNumber);
        }
        
        private static string ReturnCode(int randomNum, int guessNum)
        {
            string random = randomNum.ToString();
            string guess = guessNum.ToString();

            string response = string.Empty;
            for (int i = 0; i < random.Length; i++)
            {
                if (guess[i] == random[i])
                {
                    response += "+";
                    continue;
                }

                if (random.Contains(guess[i]))
                {
                    response += "-";
                }
                else
                {
                    response += "_";
                }
            }

            return response;
        }
        
    }
}
