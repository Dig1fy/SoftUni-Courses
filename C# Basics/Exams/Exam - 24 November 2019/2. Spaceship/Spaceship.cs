using System;

namespace Exam24November2019
{
    class Program
    {
        static void Main()
        {
            double shipWidth = double.Parse(Console.ReadLine());
            double shipLength = double.Parse(Console.ReadLine());
            double shipHight = double.Parse(Console.ReadLine());
            double astronautsAverageHight = double.Parse(Console.ReadLine());

            double shipArea = shipLength * shipWidth * shipHight;
            double astronautNeededSpace = 2 * 2 * (astronautsAverageHight + 0.40);
            double availability = Math.Floor(shipArea / astronautNeededSpace);

            if (availability >= 3 && availability <= 10)
            {
                Console.WriteLine($"The spacecraft holds {availability} astronauts.");
            }
            else if (availability < 3)
            {
                Console.WriteLine("The spacecraft is too small.");
            }
            else if (availability > 10)
            {
                Console.WriteLine("The spacecraft is too big.");
            }
        }
    }
}