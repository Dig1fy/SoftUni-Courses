using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RageQuit
{
    class Program
    {
        static void Main()
        {
            string regex = @"(?<str>[^0-9]+)(?<repeat>[0-9]+)";
            string input = Console.ReadLine();
            MatchCollection matched = Regex.Matches(input, regex);
            var sb = new StringBuilder();
            var set = new HashSet<char>();

            foreach (Match m in matched)
            {
                var str = m.Groups["str"].Value.ToUpper();
                foreach (var ch in str)
                {
                    set.Add(ch);
                }
                var repeat = int.Parse(m.Groups["repeat"].Value);

                for (int i = 0; i < repeat; i++)
                {
                    sb.Append(str);
                }
            }

            Console.WriteLine($"Unique symbols used: {sb.ToString().Distinct().Count()}");
            Console.WriteLine(sb);
        }
    }
}
