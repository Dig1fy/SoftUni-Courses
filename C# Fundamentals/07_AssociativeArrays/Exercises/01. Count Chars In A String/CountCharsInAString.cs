using System;
using System.Collections.Generic;

namespace CountCharsInAString
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            var dict = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (!(currentChar == ' '))
                {
                    if (!dict.ContainsKey(currentChar))
                    {
                        dict[currentChar] = 0;
                    }

                    dict[currentChar]++;
                }
            }

            foreach (var kvp in dict)
            {
                char chars = kvp.Key;
                int occurences = kvp.Value;
                Console.WriteLine($"{chars} -> {occurences}");
            }
        }
    }
}