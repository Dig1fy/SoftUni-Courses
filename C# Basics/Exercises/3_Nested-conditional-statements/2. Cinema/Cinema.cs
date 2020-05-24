using System;

namespace NestedConditionalStatements
{
    class Program
    {
        static void Main()
        {
            string type = Console.ReadLine();
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            double ticketPremiere = 12;
            double ticketNormal = 7.50;
            double ticketDiscount = 5;
            double price = 0;

            if (type == "Premiere")
            {
                price = rows * columns * ticketPremiere;
            }
            else if (type == "Normal")
            {
                price = rows * columns * ticketNormal;
            }
            else if (type == "Discount")
            {
                price = rows * columns * ticketDiscount;
            }

            Console.WriteLine($"{price:F2} leva");
        }
    }
}