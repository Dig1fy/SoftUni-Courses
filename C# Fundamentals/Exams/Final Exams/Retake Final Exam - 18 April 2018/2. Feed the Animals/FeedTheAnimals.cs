using System;
using System.Collections.Generic;
using System.Linq;

namespace FeedTheAnimals
{
    class Program
    {
        static void Main()
        {
            var nameAndFood = new Dictionary<string, int>();
            var areaAndUnfedAnimals = new Dictionary<string, int>();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Last Info")
            {
                var commandArr = command.Split(":").ToArray();
                var action = commandArr[0];
                var animal = commandArr[1];
                var food = int.Parse(commandArr[2]);
                var area = commandArr[3];

                if (action == "Add")
                {
                    if (!areaAndUnfedAnimals.ContainsKey(area))
                    {
                        areaAndUnfedAnimals.Add(area, 1);
                    }
                    else if (areaAndUnfedAnimals.ContainsKey(area) && !nameAndFood.ContainsKey(animal))
                    {
                        areaAndUnfedAnimals[area]++;
                    }

                    if (!nameAndFood.ContainsKey(animal))
                    {
                        nameAndFood.Add(animal, 0);
                    }

                    nameAndFood[animal] += food;
                }

                else if (action == "Feed")
                {
                    if (nameAndFood.ContainsKey(animal))
                    {
                        nameAndFood[animal] -= food;

                        if (nameAndFood[animal] <= 0)
                        {
                            Console.WriteLine($"{animal} was successfully fed");
                            nameAndFood.Remove(animal);
                            areaAndUnfedAnimals[area]--;
                        }
                    }
                }
            }

            nameAndFood = nameAndFood
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            areaAndUnfedAnimals = areaAndUnfedAnimals
                .OrderByDescending(x => x.Value)
                .ToDictionary(x => x.Key, x => x.Value);

            Console.WriteLine("Animals:");

            foreach (var animal in nameAndFood)
            {
                Console.WriteLine($"{animal.Key} -> {animal.Value}g");
            }

            Console.WriteLine("Areas with hungry animals:");

            foreach (var area in areaAndUnfedAnimals.Where(x => x.Value >= 1))
            {
                Console.WriteLine($"{area.Key} : {area.Value}");
            }
        }
    }
}
