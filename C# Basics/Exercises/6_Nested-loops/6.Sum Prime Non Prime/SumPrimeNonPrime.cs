using System;

namespace NestedLoops
{
    class Program
    {
        static void Main()
        {
            int sumPrimeNumbers = 0;
            int sumNonPrimeNumbers = 0;

            while (true)
            {
                string input = Console.ReadLine();
                bool isPrime = true;

                if (input == "stop")
                {

                    break;
                }

                int number = int.Parse(input);

                if (number < 0)
                {
                    Console.WriteLine("Number is negative.");
                    continue;
                }
                else if (number == 1)
                {
                    isPrime = false;
                }
                else
                {
                    for (int i = number; i >= 2; i--)
                    {
                        if (number % i == 0 && number != i)
                        {
                            isPrime = false;
                            break;
                        }
                    }
                }

                if (isPrime)
                {
                    sumPrimeNumbers += number;
                }
                else
                {
                    sumNonPrimeNumbers += number;
                }
            }

            Console.WriteLine($"Sum of all prime numbers is: {sumPrimeNumbers}");
            Console.WriteLine($"Sum of all non prime numbers is: {sumNonPrimeNumbers}");
        }
    }
}