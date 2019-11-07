using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FunctionalProgramming
{
    class Program
    {
        static void Main()
        {
            Func<string, int, bool> nameLength = (name, length) => name.Length == length;
            Func<string, string, bool> startsWith = (name, startString) => name.StartsWith(startString);
            Func<string, string, bool> endsWith = (name, endString) => name.EndsWith(endString);

            var names = Console.ReadLine().Split().ToList();

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Party!")
            {
                var commandArray = command
                    .Split()
                    .ToArray();

                var action = commandArray[0];
                var condition = commandArray[1];
                var parameter = commandArray[2];

                if (action == "Remove")
                {
                    switch (condition)
                    {
                        case "Length":
                            names = names.Where(x => !nameLength(x, int.Parse(parameter))).ToList();
                            break;
                        case "StartsWith":
                            names = names.Where(x => !startsWith(x, parameter)).ToList();
                            break;
                        case "EndsWith":
                            names = names.Where(x => !endsWith(x, parameter)).ToList();
                            break;
                        default:
                            break;
                    }
                }
                else if (action == "Double")
                {
                    var tempNames = new List<string>();

                    switch (condition)
                    {
                        case "Length":
                            tempNames = names.Where(x => nameLength(x, int.Parse(parameter))).ToList();
                            DoubleTheCurrentName(names, tempNames);
                            break;
                        case "StartsWith":
                            tempNames = names.Where(x => startsWith(x, parameter)).ToList();
                            DoubleTheCurrentName(names, tempNames);
                            break;
                        case "EndsWith":
                            tempNames = names.Where(x => endsWith(x, parameter)).ToList();
                            DoubleTheCurrentName(names, tempNames);
                            break;
                        default:
                            break;
                    }
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ", names)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }

        private static void DoubleTheCurrentName(List<string> names, List<string> tempNames)
        {
            foreach (var name in tempNames)
            {
                var index = names.IndexOf(name);
                names.Insert(index, name);
            }
        }
    }
}