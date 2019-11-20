using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MorseCodeTranslator
{
    class Program
    {
        static void Main()
        {
            var builder = new StringBuilder();

            var dict = new Dictionary<string, char>()
            {
                [".-"] = 'A',
                ["-..."] = 'B',
                ["-.-."] = 'C',
                ["-.."] = 'D',
                ["."] = 'E',
                ["..-."] = 'F',
                ["--."] = 'G',
                ["...."] = 'H',
                [".."] = 'I',
                [".---"] = 'J',
                ["-.-"] = 'K',
                [".-.."] = 'L',
                ["--"] = 'M',
                ["-."] = 'N',
                ["---"] = 'O',
                [".--."] = 'P',
                ["--.-"] = 'Q',
                [".-."] = 'R',
                ["..."] = 'S',
                ["-"] = 'T',
                ["..-"] = 'U',
                ["...-"] = 'V',
                [".--"] = 'W',
                ["-..-"] = 'X',
                ["-.--"] = 'Y',
                ["--.."] = 'Z'

            };

            var input = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries).ToList();
            var tempWord = string.Empty;

            for (int i = 0; i < input.Count; i++)
            {
                var currentWord = input[i].Split().ToList();

                foreach (var letter in currentWord)
                {
                    foreach (var kvp in dict)
                    {
                        if (kvp.Key == letter)
                        {
                            tempWord += kvp.Value;
                        }
                    }
                }

                builder.Append($"{tempWord} ");
                tempWord = string.Empty;
            }

            var result = builder.ToString();
            Console.WriteLine(result);
        }
    }
}
