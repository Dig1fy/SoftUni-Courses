using System;

namespace PalindromeIntegers
{
    class Program
    {
        static void Main()
        {
            string inputNumber = string.Empty;
            bool isItTrue = true;

            while ((inputNumber = Console.ReadLine()) != "END")
            {
                isItTrue = CheckIfNumIsPalindrome(inputNumber, isItTrue);

                if (isItTrue)
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine("false");
                }
            }
        }

        static bool CheckIfNumIsPalindrome(string inputNumber, bool isItTrue)
        {
            for (int i = 0; i < inputNumber.Length; i++)
            {
                if (inputNumber[i] != inputNumber[inputNumber.Length - i - 1])
                {
                    isItTrue = false;
                    break;
                }
                else
                {
                    isItTrue = true;
                }
            }

            return isItTrue;
        }
    }
}