using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main()
        {
            var input = string.Empty;
            var contestsWithPasswords = new Dictionary<string, string>();
            var usersWithContests = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var inputArr = input.Split(":")
                    .ToArray();

                contestsWithPasswords.Add(inputArr[0], inputArr[1]);
            }

            var usersInput = string.Empty;

            while ((usersInput = Console.ReadLine()) != "end of submissions")
            {
                var usersInputArr = usersInput
                    .Split("=>")
                    .ToArray();

                var currentContest = usersInputArr[0];
                var currentPassword = usersInputArr[1];
                var currentName = usersInputArr[2];
                var currentPoints = int.Parse(usersInputArr[3]);

                foreach (var (contest, password) in contestsWithPasswords.Where(x => currentContest == x.Key))
                {
                    if (currentPassword == password)
                    {
                        if (!usersWithContests.ContainsKey(currentName))
                        {
                            usersWithContests.Add(currentName, new Dictionary<string, int>());
                            usersWithContests[currentName].Add(currentContest, currentPoints);
                        }
                        if (!usersWithContests[currentName].ContainsKey(currentContest))
                        {
                            usersWithContests[currentName].Add(currentContest, currentPoints);
                        }

                        if (usersWithContests[currentName].ContainsKey(currentContest)
                            && usersWithContests[currentName][currentContest] < currentPoints)
                        {
                            usersWithContests[currentName][currentContest] = currentPoints;
                        }
                    }
                }
            }

            var topStudent = usersWithContests
                .OrderByDescending(x => x.Value.Sum(c => c.Value))
                .FirstOrDefault();

            Console.WriteLine($"Best candidate is {topStudent.Key} with total {topStudent.Value.Sum(c => c.Value)} points.");

            Console.WriteLine("Ranking: ");

            foreach (var name in usersWithContests.OrderBy(x => x.Key))
            {
                Console.WriteLine(name.Key);

                foreach (var (contest, points) in name.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {contest} -> {points}");
                }
            }
        }
    }
}