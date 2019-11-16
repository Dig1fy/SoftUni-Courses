using System;

namespace WaterOverflow
{
    class Program
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int totalCapacity = 255;
            int currentCapacity = 0;

            for (int i = 1; i <= numberOfLines; i++)
            {
                int quantities = int.Parse(Console.ReadLine());

                if (currentCapacity + quantities <= totalCapacity)
                {
                    currentCapacity += quantities;
                }
                else
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
            }

            Console.WriteLine(currentCapacity);
        }
    }
}