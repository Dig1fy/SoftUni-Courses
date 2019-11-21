using System;
using System.Text.RegularExpressions;

namespace TheIsleOfManTTRace
{
    class Program
    {
        static void Main()
        {
            var isCoordinate = false;

            while (!isCoordinate)
            {
                var input = Console.ReadLine();
                var pattern = new Regex(@"([#$%\*&]{1})(?<letters>[A-Za-z]+)\1=(?<length>\d+)!!(?<code>.+)");
                var matches = pattern.Matches(input);
                bool isMatch = pattern.IsMatch(input);

                if (!isMatch)
                {
                    Console.WriteLine("Nothing found!");
                }
                else
                {
                    foreach (Match match in matches)
                    {
                        var letters = match.Groups["letters"].Value;
                        var currentLength = int.Parse(match.Groups["length"].Value);
                        var encryptedCode = match.Groups["code"].Value;

                        if (currentLength == encryptedCode.Length)
                        {
                            var decryptedCode = DecryptTheCode(encryptedCode, currentLength);
                            Console.WriteLine($"Coordinates found! {letters} -> {decryptedCode}");
                            return;
                        }
                        else
                            Console.WriteLine("Nothing found!");
                    }
                }
            }
        }

        static string DecryptTheCode(string codee, int lengthOfCode)
        {
            var currentLetter = string.Empty;

            for (int i = 0; i < codee.Length; i++)
            {
                currentLetter += (char)(codee[i] + lengthOfCode);
            }

            return currentLetter;
        }
    }
}
