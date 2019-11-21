using System;
using System.Text.RegularExpressions;

namespace ArrivingInKathmandu
{
    class Program
    {
        static void Main()
        {
            var pattern = new Regex(@"^(?<name>[A-Za-z0-9!@#$?]+)=(?<length>\d+)<<(?<code>.+)$");
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Last note")
            {
                var matches = pattern.Matches(input);
                bool isMatch = pattern.IsMatch(input);

                if (!isMatch)
                {
                    Console.WriteLine("Nothing found!");
                    continue;
                }

                else
                {
                    foreach (Match match in matches)
                    {
                        var name = match.Groups["name"].Value;
                        var length = int.Parse(match.Groups["length"].Value);
                        var code = match.Groups["code"].Value;

                        if (length != code.Length)
                        {
                            Console.WriteLine("Nothing found!");
                            continue;
                        }
                        else
                        {
                            var realName = string.Empty;

                            for (int i = 0; i < name.Length; i++)
                            {
                                if (char.IsLetterOrDigit(name[i]))
                                {
                                    realName += (char)name[i];
                                }
                            }

                            if (realName.Length > 0)
                            {
                                Console.WriteLine($"Coordinates found! {realName} -> {code}");
                            }
                            else
                            {
                                Console.WriteLine("Nothing found!");
                            }
                        }
                    }
                }
            }
        }
    }
}
