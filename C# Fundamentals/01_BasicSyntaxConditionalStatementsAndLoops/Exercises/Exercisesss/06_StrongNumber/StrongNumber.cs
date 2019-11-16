using System;

namespace StrongNumber
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int inputCopy = input;

            int sum = 0;

            while (inputCopy != 0)
            {
                int lastDigit = inputCopy % 10;
                int lastDigitSum = 1;

                for (int i = lastDigit; i > 0; i--)
                {
                    lastDigitSum *= i;
                }

                sum += lastDigitSum;
                inputCopy /= 10;
            }

            if (sum == input)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    }
}