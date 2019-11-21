using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace MessageDecrypter
{
    class Program
    {
        static void Main()
        {
            var num = int.Parse(Console.ReadLine());
            var pattern = @"^([\$\%]{1})(?<tag>[A-Z]{1}[a-z]{2,})\1: (?<message>\[\d+\]\|\[\d+\]\|\[\d+\]\|)$";

            for (int i = 0; i < num; i++)
            {
                var currentInput = Console.ReadLine();
                var matches = Regex.Matches(currentInput, pattern);

                if (Regex.IsMatch(currentInput, pattern))
                {
                    foreach (Match match in matches)
                    {
                        var message = match.Groups["message"].Value;
                        var tag = match.Groups["tag"].Value;
                        var result = DecryptTheMessage(message);
                        Console.WriteLine($"{tag}: {result}");
                    }
                }
                else
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
        public static string DecryptTheMessage(string input)
        {
            var tempArr = input.Split(new[] { '[', '|', ']' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            var decrypted = string.Empty;

            for (int i = 0; i < tempArr.Length; i++)
            {
                var current = int.Parse(tempArr[i]);

                decrypted += (char)current;
            }

            return decrypted;
        }
    }
}