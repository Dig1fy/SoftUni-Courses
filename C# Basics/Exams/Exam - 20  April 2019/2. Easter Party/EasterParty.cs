using System;

namespace ExamOn20April2019
{
    class Program
    {
        static void Main()
        {
            int guests = int.Parse(Console.ReadLine());
            double couvertPrice = double.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());
            double cake = 0.1 * budget;

            double price = guests * couvertPrice;

            if (guests >= 10 && guests <= 15)
            {
                price *= 0.85;
            }
            else if (guests > 15 && guests <= 20)
            {
                price *= 0.8;
            }
            else if (guests > 20)
            {
                price *= 0.75;
            }
            price += cake;

            if (budget >= price)
            {
                Console.WriteLine($"It is party time! {(budget - price):f2} leva left.");
            }
            else
            {
                Console.WriteLine($"No party! {(price - budget):f2} leva needed.");
            }
        }
    }
}