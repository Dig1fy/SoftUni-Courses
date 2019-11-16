using System;

namespace Vacation
{
    class Program
    {
        static void Main()
        {
            int groupSize = int.Parse(Console.ReadLine());
            string groupType = Console.ReadLine();
            string dayOfWeek = Console.ReadLine();
            double price = groupSize;

            if (groupType == "Students")
            {
                if (dayOfWeek == "Friday")
                {
                    price *= 8.45;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price *= 9.80;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price *= 10.46;
                }
                if (groupSize >= 30)
                {
                    price *= 0.85;
                }
            }
            else if (groupType == "Business")
            {
                if (dayOfWeek == "Friday")
                {
                    price = 10.90;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price = 15.60;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price = 16;
                }
                if (groupSize >= 100)
                {
                    groupSize -= 10;

                }

                price *= groupSize;
            }
            else if (groupType == "Regular")
            {
                if (dayOfWeek == "Friday")
                {
                    price *= 15;
                }
                else if (dayOfWeek == "Saturday")
                {
                    price *= 20;
                }
                else if (dayOfWeek == "Sunday")
                {
                    price *= 22.50;
                }
                if (groupSize >= 10 && groupSize <= 20)
                {
                    price *= 0.95;
                }
            }

            Console.WriteLine($"Total price: {price:f2}");
        }
    }
}
