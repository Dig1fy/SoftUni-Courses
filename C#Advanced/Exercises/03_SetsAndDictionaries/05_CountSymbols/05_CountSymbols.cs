using System;
using System.Collections.Generic;
using System.Linq;

namespace SetsAndDictionaries
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var symbols = new Dictionary<char, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!symbols.ContainsKey(input[i]))
                {
                    symbols.Add(input[i], 0);
                }
                symbols[input[i]]++;
            }

            symbols = symbols.OrderBy(x => x.Key).ToDictionary(x => x.Key, y => y.Value);

            foreach (var charR in symbols)
            {
                Console.WriteLine($"{charR.Key}: {charR.Value} time/s");
            }
        }
    }
}