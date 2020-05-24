using System;

namespace ConditionalStatements
{
    class Program
    {
        static void Main()
        {
            int number = int.Parse(Console.ReadLine());
            double bonusPoints = 0;

            if (number < 100)
            {
                bonusPoints = 5;
            }
            else if (number >= 100 && number < 1000)
            {
                bonusPoints = 0.2 * number;
            }
            else if (number > 1000)
            {
                bonusPoints = 0.1 * number;
            }

            if (number % 2 == 0)
            {
                bonusPoints = bonusPoints + 1;
            }

            if (number % 10 == 5)
            {
                bonusPoints = bonusPoints + 2;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(number + bonusPoints);
        }
    }
}