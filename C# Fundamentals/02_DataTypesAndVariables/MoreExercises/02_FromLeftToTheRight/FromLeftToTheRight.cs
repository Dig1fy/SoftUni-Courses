using System;

namespace FromLeftToTheRight
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                string numAsString = Console.ReadLine();
                string firstNumOfString = numAsString.Substring(0, numAsString.IndexOf(" "));
                string secondNumOfString = numAsString.Substring(numAsString.IndexOf(" ") + 1);

                long firstNum = long.Parse(firstNumOfString);
                long secondNum = long.Parse(secondNumOfString);
                long sumOfDigits = 0;

                long biggestNum = Math.Max(firstNum, secondNum);
                biggestNum = Math.Abs(biggestNum);

                while (biggestNum != 0)
                {
                    sumOfDigits += (biggestNum % 10);
                    biggestNum /= 10;
                }

                Console.WriteLine(sumOfDigits);
            }
        }
    }
}