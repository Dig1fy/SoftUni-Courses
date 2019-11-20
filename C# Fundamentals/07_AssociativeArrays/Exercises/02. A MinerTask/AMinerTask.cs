using System;
using System.Collections.Generic;

namespace MinerTask
{
    class Program
    {
        static void Main()
        {
            string input = string.Empty;
            int counter = 1;
            var dict = new Dictionary<string, int>();

            var currentWord = string.Empty;
            var currentQy = 0;

            while ((input = Console.ReadLine()) != "stop")
            {
                if (counter % 2 != 0)
                {
                    currentWord = input;
                }

                else
                {
                    currentQy = int.Parse(input);

                    if (!dict.ContainsKey(currentWord))
                    {
                        dict[currentWord] = currentQy;
                    }
                    else
                    {
                        dict[currentWord] += currentQy;
                    }

                    currentQy = 0;
                    currentWord = string.Empty;
                }

                counter++;
            }

            foreach (var kvp in dict)
            {
                currentWord = kvp.Key;
                currentQy = kvp.Value;
                Console.WriteLine($"{currentWord} -> {currentQy}");
            }
        }
    }
}