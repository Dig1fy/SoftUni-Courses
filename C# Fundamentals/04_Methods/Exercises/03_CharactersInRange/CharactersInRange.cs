using System;

namespace CharactersInRange
{
    class Program
    {
        static void Main()
        {
            string password = Console.ReadLine();
            bool isLengthValid = false;
            bool areOnlyDigitsAndLetters = true;
            bool areThereAtLeastTwoDigits = false;

            if (password.Length >= 6 && password.Length <= 10)
            {
                isLengthValid = true;
            }
            if (!isLengthValid)
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
            }

            areOnlyDigitsAndLetters = CheckForDigitsAndLetters(password, areOnlyDigitsAndLetters);
            areThereAtLeastTwoDigits = CheckForAtLeastTwoDigits(password, areThereAtLeastTwoDigits);

            if (!areThereAtLeastTwoDigits)
            {
                Console.WriteLine("Password must have at least 2 digits");
            }

            if (isLengthValid && areThereAtLeastTwoDigits && areOnlyDigitsAndLetters)
            {
                Console.WriteLine("Password is valid");
            }
        }

        private static bool CheckForAtLeastTwoDigits(string password, bool areThereAtLeastTwoDigits)
        {
            int digitCounter = 0;

            for (int i = 0; i < password.Length; i++)
            {
                char currentChar = password[i];

                if (currentChar >= '0' && currentChar <= '9')
                {
                    digitCounter++;

                    if (digitCounter == 2)
                    {
                        areThereAtLeastTwoDigits = true;
                        break;
                    }
                }
            }

            return areThereAtLeastTwoDigits;
        }

        private static bool CheckForDigitsAndLetters(string password, bool areOnlyDigitsAndLetters)
        {
            for (int i = 0; i < password.Length; i++)
            {
                areOnlyDigitsAndLetters = char.IsLetterOrDigit(password[i]);
                if (!areOnlyDigitsAndLetters)
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    break;
                }
            }

            return areOnlyDigitsAndLetters;
        }
    }
}