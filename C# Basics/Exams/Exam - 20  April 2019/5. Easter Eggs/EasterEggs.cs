using System;

namespace ExamOn20April2019
{
    class Program
    {
        static void Main()
        {
            int eggsQy = int.Parse(Console.ReadLine());
            int red = 0;
            int orange = 0;
            int blue = 0;
            int green = 0;
            string colorOfMaxEggs = string.Empty;
            int maxEggs = 0;

            for (int i = 1; i <= eggsQy; i++)
            {
                string eggColor = Console.ReadLine();
                if (eggColor == "red")
                {
                    red++;
                }
                else if (eggColor == "orange")
                {
                    orange++;
                }
                else if (eggColor == "blue")
                {
                    blue++;
                }
                else if (eggColor == "green")
                {
                    green++;
                }
            }

            maxEggs = Math.Max(Math.Max(red, orange), Math.Max(blue, green));

            if (maxEggs == red)
            {
                colorOfMaxEggs = "red";
            }
            else if (maxEggs == orange)
            {
                colorOfMaxEggs = "orange";
            }
            else if (maxEggs == blue)
            {
                colorOfMaxEggs = "blue";
            }
            else if (maxEggs == green)
            {
                colorOfMaxEggs = "green";
            }

            Console.WriteLine($"Red eggs: {red}");
            Console.WriteLine($"Orange eggs: {orange}");
            Console.WriteLine($"Blue eggs: {blue}");
            Console.WriteLine($"Green eggs: {green}");
            Console.WriteLine($"Max eggs: {maxEggs} -> {colorOfMaxEggs}");
        }
    }
}