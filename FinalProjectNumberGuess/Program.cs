using System;

class FinalProjectNumberGuess
{
    static void Main()
    {
        /*
         * user guesses a number from their preffered range.
         */
        Console.WriteLine("This is A Number Guessing Game");
        Console.WriteLine("Enter your preferred range.");

        int minRange = Int32.Parse(Console.ReadLine());
        int maxRange = Int32.Parse(Console.ReadLine());
        int randomNumber = new Random().Next(minRange, maxRange + 1);
        int guesses = 0;

        while(true)
        {
            Console.Write("Enter you guess: ");
            string inputString = Console.ReadLine();
            if (IsInteger(inputString))
            {
                int guess = Int32.Parse(inputString);
                if (guess != randomNumber)
                {
                    guesses++;
                    if (guess < randomNumber)
                    {
                        Console.WriteLine("Too low. Try again.");
                    }
                    else if (guess > randomNumber)
                    {
                        Console.WriteLine("Too high. Try again.");
                    }
                }
                else
                {
                    Console.WriteLine("Congratulations! You guessed the number " + randomNumber + " in " + guesses + " tries.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input, enter a number.");
            }
            
        }
    }
    static bool IsInteger(string str)
    {
        foreach (char c in str)
        {
            if (!char.IsDigit(c))
            {
                return false;
            }
        }
        return true;
    }
}