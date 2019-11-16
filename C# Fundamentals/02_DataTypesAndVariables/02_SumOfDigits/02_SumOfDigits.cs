using System;

namespace SumOfDigits
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int number = input;
            int sum = 0;

            while (number != 0)
            {
                int lastDigit = number % 10;
                sum += lastDigit;
                number /= 10;
            }

            Console.WriteLine(sum);
        }
    }
}