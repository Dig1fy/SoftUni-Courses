using System;

namespace ExamOn20April2019
{
    class Program
    {
        static void Main()
        {
            string destination = Console.ReadLine();
            string dates = Console.ReadLine();
            int nights = int.Parse(Console.ReadLine());
            double price = 0;

            double _21MarchFrance = 30;
            double _24MarchFrance = 35;
            double _28MarchFrance = 40;

            double _21MarchItaly = 28;
            double _24MarchItaly = 32;
            double _28MarchItaly = 39;

            double _21MarchGermany = 32;
            double _24MarchGermany = 37;
            double _28MarchGermany = 43;

            if (destination == "France")
            {
                if (dates == "21-23")
                {
                    price += _21MarchFrance;
                }
                else if (dates == "24-27")
                {
                    price = _24MarchFrance;
                }
                else if (dates == "28-31")
                {
                    price = _28MarchFrance;
                }
            }
            else if (destination == "Italy")
            {
                if (dates == "21-23")
                {
                    price += _21MarchItaly;
                }
                else if (dates == "24-27")
                {
                    price = _24MarchItaly;
                }
                else if (dates == "28-31")
                {
                    price = _28MarchItaly;
                }
            }
            else if (destination == "Germany")
            {
                if (dates == "21-23")
                {
                    price += _21MarchGermany;
                }
                else if (dates == "24-27")
                {
                    price = _24MarchGermany;
                }
                else if (dates == "28-31")
                {
                    price = _28MarchGermany;
                }
            }

            price *= nights;

            Console.WriteLine($"Easter trip to {destination} : {price:f2} leva.");
        }
    }
}