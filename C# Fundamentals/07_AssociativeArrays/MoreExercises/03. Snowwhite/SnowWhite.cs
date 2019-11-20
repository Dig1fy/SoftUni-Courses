using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowWhite
{
    class Program
    {
        static void Main()
        {
            var allDwarfs = new Dictionary<string, Dictionary<string, int>>();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                var input = command
                    .Split(" <:> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var hatColor = input[1];
                var name = input[0];
                var physics = int.Parse(input[2]);

                if (!allDwarfs.ContainsKey(hatColor))
                {
                    allDwarfs.Add(hatColor, new Dictionary<string, int>());
                    allDwarfs[hatColor][name] = physics;
                }

                else if (!allDwarfs[hatColor].ContainsKey(name))
                {
                    allDwarfs[hatColor].Add(name, physics);
                }

                if (allDwarfs[hatColor][name] < physics)
                {
                    allDwarfs[hatColor][name] = physics;
                }
            }

            var sortedListOfDwarfs = new Dictionary<string, int>();

            foreach (var hatColor in allDwarfs.OrderByDescending(x => x.Value.Count()))
            {
                foreach (var dwarf in hatColor.Value)
                {
                    sortedListOfDwarfs.Add($"({hatColor.Key}) {dwarf.Key} <-> ", dwarf.Value);
                }
            }

            foreach (var dwarf in sortedListOfDwarfs.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{dwarf.Key}{dwarf.Value}");
            }
        }
    }
}