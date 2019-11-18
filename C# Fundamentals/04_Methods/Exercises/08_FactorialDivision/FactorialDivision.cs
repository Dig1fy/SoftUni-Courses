using System;

namespace FactorialDivision
{
    class Program
    {
        static void Main()
        {
            long firstNumber = long.Parse(Console.ReadLine());
            long secondNumber = long.Parse(Console.ReadLine());

            if (secondNumber == 0 || firstNumber == 0)
            {
                Console.WriteLine("0");
                return;
            }

            decimal result = (decimal)GetFactorial(firstNumber) / (decimal)GetFactorial(secondNumber);
            Console.WriteLine($"{result:f2}");
        }

        static long GetFactorial(long number)
        {
            if (number == 0)
            {
                return 0;
            }

            long currentFactorial = 1;

            for (long i = 1; i <= number; i++)
            {
                currentFactorial *= i;
            }

            return currentFactorial;
        }
    }
}