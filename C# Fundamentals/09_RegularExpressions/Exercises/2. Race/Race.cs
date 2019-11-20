using System;
using System.Collections.Generic;
using System.Linq;

namespace Race
{
    class Program
    {
        static void Main()
        {
            var listOfParticipants = Console.ReadLine().Split(", ").ToList();
            var participantsWithDistance = new Dictionary<string, int>();
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "end of race")
            {
                var currentName = string.Empty;
                var currentDistance = 0;

                for (int i = 0; i < command.Length; i++)
                {
                    if (char.IsDigit(command[i]))
                    {
                        currentDistance += (command[i] - '0');
                    }
                    else if (char.IsLetter(command[i]))
                    {
                        currentName += command[i];
                    }
                }

                if (listOfParticipants.Contains(currentName))
                {
                    if (!participantsWithDistance.ContainsKey(currentName) && currentDistance >= 0)
                    {
                        participantsWithDistance[currentName] = currentDistance;
                    }
                    else
                    {
                        participantsWithDistance[currentName] += currentDistance;
                    }
                }
            }

            participantsWithDistance = participantsWithDistance
                .OrderByDescending(x => x.Value)
                 .Take(3)
                 .ToDictionary(x => x.Key, x => x.Value);
            var result = participantsWithDistance.Keys.ToList();

            Console.WriteLine($"1st place: {result[0]}");
            Console.WriteLine($"2nd place: {result[1]}");
            Console.WriteLine($"3rd place: {result[2]}");
        }
    }
}
