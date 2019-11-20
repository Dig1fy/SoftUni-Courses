using System;
using System.Collections.Generic;
using System.Linq;

namespace SnowWhite_SecondWay
{
    class Program
    {
        static void Main()
        {
            var allDwarfs = new Dictionary<string, List<Dwarf>>();
            var result = new List<Dwarf>();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Once upon a time")
            {
                var input = command.Split(" <:> ").ToList();
                var name = input[0];
                var color = input[1];
                var physic = int.Parse(input[2]);

                if (!allDwarfs.ContainsKey(color))
                {
                    allDwarfs.Add(color, new List<Dwarf>());
                }

                if (allDwarfs[color].Any(x => x.Name == name))
                {
                    var reffDwarf = allDwarfs[color].FirstOrDefault(x => x.Name == name);
                    reffDwarf.Physic = Math.Max(physic, reffDwarf.Physic);
                }
                else
                {
                    var newDwarf = new Dwarf();
                    newDwarf.Name = name;
                    newDwarf.Color = color;
                    newDwarf.Physic = physic;
                    allDwarfs[color].Add(newDwarf);
                    result.Add(newDwarf);
                }
            }

            result = result.OrderByDescending(x => x.Physic)
                    .ThenByDescending(x => allDwarfs[x.Color].Count()).ToList();

            foreach (var dwarf in result)
            {
                Console.WriteLine($"({dwarf.Color}) {dwarf.Name} <-> {dwarf.Physic}");
            }
        }
        class Dwarf
        {
            public string Name { get; set; }

            public string Color { get; set; }

            public int Physic { get; set; }
        }
    }
}