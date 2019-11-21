using System;
using System.Collections.Generic;
using System.Linq;

namespace Concert
{
    class Program
    {
        static void Main()
        {
            var bandsWithMembers = new Dictionary<string, List<string>>();
            var bandsTime = new Dictionary<string, int>();
            var totalTime = 0;

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "start of concert")
            {
                var input = command.Split("; ");
                var action = input[0];
                var band = input[1];

                switch (action)
                {
                    case "Add":
                        var members = input[2].Split(", ");

                        if (!bandsWithMembers.ContainsKey(band))
                        {
                            bandsWithMembers.Add(band, new List<string>());
                        }

                        for (int i = 0; i < members.Length; i++)
                        {
                            if (!bandsWithMembers[band].Contains(members[i]))
                            {
                                bandsWithMembers[band].Add(members[i]);
                            }
                        }
                        break;
                    case "Play":
                        var time = int.Parse(input[2]);

                        if (!bandsTime.ContainsKey(band))
                        {
                            bandsTime.Add(band, 0);
                        }

                        bandsTime[band] += time;
                        totalTime += time;
                        break;
                    default:
                        break;
                }
            }

            var bandForPrint = Console.ReadLine();

            Console.WriteLine($"Total time: {totalTime}");

            foreach (var band in bandsTime.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{band.Key} -> {band.Value}");
            }

            Console.WriteLine(bandForPrint);

            foreach (var member in bandsWithMembers[bandForPrint])
            {
                Console.WriteLine($"=> {member}");
            }
        }
    }
}
