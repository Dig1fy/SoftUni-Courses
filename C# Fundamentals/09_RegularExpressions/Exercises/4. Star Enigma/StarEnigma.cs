using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace StarEnigma
{
    class Program
    {
        static void Main()
        {
            //80 out of 100 points. I never found which tests failed. 

            var num = int.Parse(Console.ReadLine());
            var pattern = "[starSTAR]";
            var attackedPlanets = new Dictionary<string, int>();
            var destroyedPlanets = new Dictionary<string, int>();

            var patternPlanet = 
                @"[^@\-!:>]?@(?<planet>[A-Za-z]+)[^@\-!:>]?:(?<population>\d+)[^@\-!:>]?!(?<AD>[AD])![^@\-!:>]?->(?<soldiers>\d+)";

            for (int i = 0; i < num; i++)
            {
                var initialInput = Console.ReadLine();
                var matchCount = Regex.Matches(initialInput, pattern).Count();
                var finalString = string.Empty;

                for (int r = 0; r < initialInput.Length; r++)
                {
                    finalString += (char)(initialInput[r] - matchCount);
                }

                var currentMatch = Regex.Matches(finalString, patternPlanet);

                foreach (Match match in currentMatch)
                {
                    var planet = match.Groups["planet"].Value;
                    var name = match.Groups["AD"].Value;
                    if (name == "A" && !attackedPlanets.ContainsKey(planet))
                    {
                        attackedPlanets.Add(planet, 1);
                    }
                    else if (name == "D" && !destroyedPlanets.ContainsKey(planet))
                    {
                        destroyedPlanets.Add(planet, 1);
                    }
                }
            }

            var totalAttacked = attackedPlanets.Values.Sum();
            var totalDestroyed = destroyedPlanets.Values.Sum();
            Console.WriteLine($"Attacked planets: {totalAttacked}");

            if (totalAttacked > 0)
            {
                foreach (var planet in attackedPlanets.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-> {planet.Key}");
                }
            }

            Console.WriteLine($"Destroyed planets: {totalDestroyed}");

            if (totalDestroyed > 0)
            {
                foreach (var planet in destroyedPlanets.OrderBy(x => x.Key))
                {
                    Console.WriteLine($"-> {planet.Key}");
                }
            }
        }
    }
}
