using System;
using System.Text;
using System.Text.RegularExpressions;

namespace Concert
{
    class Program
    {
        static void Main()
        {
            var input = string.Empty;
            var pattern = @"^(?<artist>[A-Z]{1}[a-z ']+):((?<song>[A-Z\s]+))$";
            var builder = new StringBuilder();

            while ((input = Console.ReadLine()) != "end")
            {
                if (Regex.IsMatch(input, pattern))
                {
                    var matches = Regex.Matches(input, pattern);

                    foreach (Match match in matches)
                    {
                        var artist = match.Groups["artist"].Value;
                        var song = match.Groups["song"].Value;

                        var currentDecryption = Decrypt(input, artist.Length);
                        builder.AppendLine($"Successful encryption: {currentDecryption}");
                    }
                }
                else
                {
                    builder.AppendLine("Invalid input!");
                }
            }

            Console.WriteLine(builder.ToString());
        }

        public static string Decrypt(string input, int length)
        {
            var result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == ':')
                {
                    result += '@';
                }
                else if (input[i] == ' ' || input[i] == '\'')
                {
                    result += input[i];
                }
                else if (input[i] >= 65 && input[i] <= 90 && input[i] + length > 90)
                {
                    result += (char)(input[i] + length - 26);
                }
                else if (input[i] >= 65 && input[i] <= 90 && input[i] + length <= 90)
                {
                    result += (char)(input[i] + length);
                }
                else if (input[i] >= 97 && input[i] <= 122 && input[i] + length <= 122)
                {
                    result += (char)(input[i] + length);
                }
                else if (input[i] >= 97 && input[i] <= 122 && input[i] + length > 122)
                {
                    result += (char)(input[i] + length - 26);
                }
            }

            return result;
        }
    }
}
