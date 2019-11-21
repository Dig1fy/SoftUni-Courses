using System;
using System.Collections.Generic;
using System.Linq;

namespace PracticeSession
{
    class Program
    {
        static void Main()
        {
            var listOfRoads = new Dictionary<string, List<string>>();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "END")
            {
                var input = command
                    .Split("->")
                    .ToArray();
                var action = input[0];
                var road = input[1];

                if (action == "Add")
                {
                    var racer = input[2];
                    if (!listOfRoads.ContainsKey(road))
                    {
                        listOfRoads.Add(road, new List<string>());
                    }

                    listOfRoads[road].Add(racer);
                }
                else if (action == "Move")
                {
                    var racer = input[2];
                    var newRoad = input[3];

                    if (listOfRoads[road].Contains(racer))
                    {
                        listOfRoads[road].Remove(racer);
                        if (!listOfRoads.ContainsKey(newRoad))
                        {
                            listOfRoads.Add(newRoad, new List<string>());
                        }
                        else if (listOfRoads.ContainsKey(newRoad) && !listOfRoads[newRoad].Contains(racer))
                        {
                            listOfRoads[newRoad].Add(racer);
                        }
                    }
                }
                else if (action == "Close")
                {
                    if (listOfRoads.ContainsKey(road))
                    {
                        listOfRoads.Remove(road);
                    }
                }
            }

            Console.WriteLine("Practice sessions:");

            foreach (var road in listOfRoads.OrderByDescending(x => x.Value.Count).ThenBy(x => x.Key))
            {
                Console.WriteLine(road.Key);

                foreach (var racer in road.Value)
                {
                    Console.WriteLine($"++{racer}");
                }
            }
        }
    }
}
