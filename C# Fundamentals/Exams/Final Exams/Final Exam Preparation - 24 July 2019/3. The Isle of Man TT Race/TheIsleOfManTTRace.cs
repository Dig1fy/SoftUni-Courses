using System;
using System.Text;
using System.Text.RegularExpressions;

namespace TheIsleOfManTTRace
{
    class Program
    {
        static void Main()
        {
            var isMatch = false;
            var builder = new StringBuilder();

            while (!isMatch)
            {
                var input = Console.ReadLine();
                var pattern = @"([#$%*&]{1})(?<racer>[A-Za-z]+)\1=(?<length>\d+)!!(?<code>.+)$";
                var matches = Regex.Matches(input, pattern);

                if (!Regex.IsMatch(input, pattern))
                {
                    builder.AppendLine("Nothing found!");
                    continue;
                }

                else
                {
                    foreach (Match match in matches)
                    {
                        var racer = match.Groups["racer"].Value;
                        var length = int.Parse(match.Groups["length"].Value);
                        var code = match.Groups["code"].Value;

                        if (code.Length == length)
                        {
                            var decrypted = GetTheCodeDecrypted(code, length);
                            builder.AppendLine($"Coordinates found! {racer} -> {decrypted}");
                            isMatch = true;
                        }
                        else
                        {
                            builder.AppendLine("Nothing found!");
                        }
                    }
                }
            }

            var result = builder.ToString();
            Console.WriteLine(result);
        }

        public static string GetTheCodeDecrypted(string input, int length)
        {
            var decrypted = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                decrypted += (char)(input[i] + length);
            }
            return decrypted;
        }
    }
}
