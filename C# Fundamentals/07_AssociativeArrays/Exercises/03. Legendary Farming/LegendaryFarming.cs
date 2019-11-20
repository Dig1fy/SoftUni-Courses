using System;
using System.Collections.Generic;
using System.Linq;

namespace LegendaryFarming
{
    class Program
    {
        static void Main()
        {
            var keyMaterials = new Dictionary<string, int>();
            keyMaterials["motes"] = 0;
            keyMaterials["shards"] = 0;
            keyMaterials["fragments"] = 0;

            var junkMaterials = new Dictionary<string, int>();
            bool isThereLegendary = false;
            string legendaryItem = string.Empty;

            while (!isThereLegendary)
            {
                string initialInput = Console.ReadLine().ToLower();
                string[] input = initialInput.Split().ToArray();

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string currentMaterial = input[i + 1];

                    if (currentMaterial == "shards" || currentMaterial == "fragments" || currentMaterial == "motes")
                    {
                        keyMaterials[currentMaterial] += quantity;

                        if (keyMaterials[currentMaterial] >= 250)
                        {
                            keyMaterials[currentMaterial] -= 250;

                            switch (currentMaterial)
                            {
                                case "shards":
                                    legendaryItem = "Shadowmourne"; 
                                    break;
                                case "fragments":
                                    legendaryItem = "Valanyr"; 
                                    break;
                                case "motes":
                                    legendaryItem = "Dragonwrath"; 
                                    break;
                                default:
                                    break;
                            }

                            isThereLegendary = true;
                            break;
                        }
                    }

                    else
                    {
                        if (!junkMaterials.ContainsKey(currentMaterial))
                        {
                            junkMaterials[currentMaterial] = 0;
                        }
                        junkMaterials[currentMaterial] += quantity;
                    }
                }
            }

            Console.WriteLine($"{legendaryItem} obtained!");

            keyMaterials = keyMaterials
                .OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            junkMaterials = junkMaterials
                .OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var item in keyMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }

            foreach (var item in junkMaterials)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}