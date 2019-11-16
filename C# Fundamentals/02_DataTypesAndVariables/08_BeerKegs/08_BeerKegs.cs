using System;

namespace BeerKegs
{
    class Program
    {
        static void Main()
        {
            int numberOfKegs = int.Parse(Console.ReadLine());
            string biggestKeg = string.Empty;
            double biggestVolume = 0;
            double volume = 0;

            for (int i = 1; i <= numberOfKegs; i++)
            {
                string model = Console.ReadLine();
                double radius = double.Parse(Console.ReadLine());
                int heigh = int.Parse(Console.ReadLine());
                volume = Math.PI * radius * radius * heigh;

                if (volume > biggestVolume)
                {
                    biggestVolume = volume;
                    biggestKeg = model;
                }
            }

            Console.WriteLine(biggestKeg);
        }
    }
}