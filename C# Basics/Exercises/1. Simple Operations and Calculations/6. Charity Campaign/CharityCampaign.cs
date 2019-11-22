using System;

namespace SimpleOperationsAndCalculations
{
    class Program
    {
        static void Main()
        {
            int daysOfEvent = int.Parse(Console.ReadLine());
            int bakersCount = int.Parse(Console.ReadLine());
            int cakes = int.Parse(Console.ReadLine());
            int waffles = int.Parse(Console.ReadLine());
            int pancakes = int.Parse(Console.ReadLine());

            int cakePrice = 45;
            double wafflePrice = 5.80;
            double pancakePrice = 3.20;

            double profitPerDay = bakersCount * ((cakes * cakePrice) + (waffles * wafflePrice) + (pancakes * pancakePrice));
            double profitXDays = profitPerDay * daysOfEvent;
            double netProfit = profitXDays - profitXDays / 8;

            Console.WriteLine($"{netProfit:F2}");
        }
    }
}