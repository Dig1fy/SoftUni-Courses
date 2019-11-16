using System;

namespace SpiceMustFlow
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int totalSpice = 0;
            int dailyConsumption = 26;
            int daysCounter = 0;

            for (int index = input; index >= 100; index -= 10)
            {
                daysCounter++;
                totalSpice += (index - dailyConsumption);
            }

            if (totalSpice - dailyConsumption >= 0)
            {
                totalSpice -= 26;
            }

            Console.WriteLine(daysCounter);
            Console.WriteLine(totalSpice);
        }
    }
}