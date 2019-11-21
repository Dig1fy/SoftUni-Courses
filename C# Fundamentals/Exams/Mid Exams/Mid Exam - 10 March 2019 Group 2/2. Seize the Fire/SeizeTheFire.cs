using System;
using System.Collections.Generic;
using System.Linq;

namespace SeizeTheFire
{
    class Program
    {
        static void Main()
        {
            string[] input = Console.ReadLine()
                .Split("#", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            int water = int.Parse(Console.ReadLine());
            double totalEffort = 0;
            int totalFire = 0;
            bool isItLegit = false;
            int counter = 0;
            List<int> numbersForPrint = new List<int>();

            for (int i = 0; i < input.Length; i++)
            {
                string[] current = input[i]
                    .Split(new[] { "=", " " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string typeOfFire = current[0];
                int valueOfFire = int.Parse(current[1]);
                isItLegit = false;

                switch (typeOfFire)
                {
                    case "High":
                        if (valueOfFire >= 81 && valueOfFire < 126 && water >= valueOfFire) 
                        {
                            isItLegit = true;
                        }
                        break;

                    case "Medium":
                        if (valueOfFire >= 51 && valueOfFire < 81 && water >= valueOfFire) 
                        {
                            isItLegit = true;
                        }
                        break;

                    case "Low":
                        if (valueOfFire >= 1 && valueOfFire < 51 && water >= valueOfFire) 
                        {
                            isItLegit = true;
                        }
                        break;

                    default:
                        break;
                }

                if (isItLegit)
                {
                    counter++;
                    water -= valueOfFire;
                    totalEffort += Math.Round(0.25 * valueOfFire, 2);
                    totalFire += valueOfFire;
                    numbersForPrint.Add(valueOfFire);
                }
            }

            Console.WriteLine("Cells:");

            foreach (var num in numbersForPrint)
            {
                Console.WriteLine($" - {num}");
            }

            Console.WriteLine($"Effort: {totalEffort:f2}");
            Console.WriteLine($"Total Fire: {totalFire}");
        }
    }
}
