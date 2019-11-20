using System;
using System.Collections.Generic;
using System.Linq;

namespace Ranking
{
    class Program
    {
        static void Main()
        {
            string input = string.Empty;
            var modulesWithPasswords = new Dictionary<string, string>();
            var nameWithModuleAndPoints = new Dictionary<string, Dictionary<string, int>>();

            while ((input = Console.ReadLine()) != "end of contests")
            {
                var inputArr = input
                    .Split(":")
                    .ToArray();
                var module = inputArr[0];
                var modulePassword = inputArr[1];

                if (!modulesWithPasswords.ContainsKey(module))
                {
                    modulesWithPasswords[module] = modulePassword;
                }
            }

            while ((input = Console.ReadLine()) != "end of submissions")
            {
                var inputArr = input.Split("=>").ToArray();
                var contestSubmission = inputArr[0];
                var passwordSubmission = inputArr[1];
                var nameSubmission = inputArr[2];
                var pointsSubmission = int.Parse(inputArr[3]);

                if (modulesWithPasswords.ContainsKey(contestSubmission) &&
                    modulesWithPasswords.ContainsValue(passwordSubmission))
                {
                    if (nameWithModuleAndPoints.ContainsKey(nameSubmission) == false)
                    {
                        nameWithModuleAndPoints.Add(nameSubmission, new Dictionary<string, int>());
                        nameWithModuleAndPoints[nameSubmission].Add(contestSubmission, pointsSubmission);
                    }

                    if (nameWithModuleAndPoints[nameSubmission].ContainsKey(contestSubmission))
                    {
                        if (nameWithModuleAndPoints[nameSubmission][contestSubmission] < pointsSubmission)
                        {
                            nameWithModuleAndPoints[nameSubmission][contestSubmission] = pointsSubmission;
                        }
                    }
                    else
                    {
                        nameWithModuleAndPoints[nameSubmission].Add(contestSubmission, pointsSubmission);
                    }
                }
            }

            var userTotalPoints = new Dictionary<string, int>();

            foreach (var kvp in nameWithModuleAndPoints)
            {
                userTotalPoints[kvp.Key] = kvp.Value.Values.Sum();
            }

            int bestPoints = userTotalPoints.Values.Max();

            foreach (var kvp in userTotalPoints)
            {
                if (kvp.Value == bestPoints)
                {
                    Console.WriteLine($"Best candidate is {kvp.Key} with total {kvp.Value} points.");
                }
            }

            Console.WriteLine($"Ranking: ");
            nameWithModuleAndPoints = nameWithModuleAndPoints
                .OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);

            foreach (var name in nameWithModuleAndPoints)
            {
                Dictionary<string, int> tempDict = name.Value;

                tempDict = tempDict
                    .OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

                Console.WriteLine($"{name.Key}");

                foreach (var kvp in tempDict)
                {
                    Console.WriteLine($"#  {kvp.Key} -> {kvp.Value}");
                }
            }
        }
    }
}