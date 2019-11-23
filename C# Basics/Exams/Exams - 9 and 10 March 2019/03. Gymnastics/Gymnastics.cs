using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            string country = Console.ReadLine();
            string instrument = Console.ReadLine();

            double ribbonRussia = 9.100 + 9.400;
            double hoopRussia = 9.300 + 9.800;
            double ropeRussia = 9.600 + 9.000;

            double ribbonBulgaria = 9.600 + 9.400;
            double hoopBulgaria = 9.550 + 9.750;
            double ropeBulgaria = 9.500 + 9.400;

            double ribbonItaly = 9.200 + 9.500;
            double hoopItaly = 9.450 + 9.350;
            double ropeItaly = 9.700 + 9.150;

            double score = 0;

            if (country == "Russia")
            {
                if (instrument == "ribbon")
                {
                    score = ribbonRussia;
                }
                else if (instrument == "hoop")
                {
                    score = hoopRussia;
                }
                else if (instrument == "rope")
                {
                    score = ropeRussia;
                }
            }
            else if (country == "Bulgaria")
            {
                if (instrument == "ribbon")
                {
                    score = ribbonBulgaria;
                }
                else if (instrument == "hoop")
                {
                    score = hoopBulgaria;
                }
                else if (instrument == "rope")
                {
                    score = ropeBulgaria;
                }
            }
            else if (country == "Italy")
            {
                if (instrument == "ribbon")
                {
                    score = ribbonItaly;
                }
                else if (instrument == "hoop")
                {
                    score = hoopItaly;
                }
                else if (instrument == "rope")
                {
                    score = ropeItaly;
                }
            }

            double percentage = (1 - (score / 20)) * 100;
            Console.WriteLine($"The team of {country} get {score:f3} on {instrument}.");
            Console.WriteLine($"{percentage:f2}%");
        }
    }
}