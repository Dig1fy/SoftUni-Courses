using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main()
        {
            var numOfClothes = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();

            for (int i = 0; i < numOfClothes; i++)
            {
                var input = Console.ReadLine().Split(" -> ").ToArray();
                var color = input[0];

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                var clothes = input[1].Split(",").ToArray();

                for (int j = 0; j < clothes.Length; j++)
                {
                    var currentCloth = clothes[j];

                    if (!wardrobe[color].ContainsKey(currentCloth))
                    {
                        wardrobe[color].Add(currentCloth, 0);
                    }

                    wardrobe[color][currentCloth]++;
                }
            }

            var desireArgs = Console.ReadLine()
                .Split()
                .ToArray();

            var desiredColor = desireArgs[0];
            var desiredCloth = desireArgs[1];

            foreach (var color in wardrobe)
            {
                Console.WriteLine($"{color.Key} clothes:");

                foreach (var cloth in color.Value)
                {
                    if (color.Key == desiredColor && cloth.Key == desiredCloth)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                }
            }
        }
    }
}