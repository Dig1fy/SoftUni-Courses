using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtractEmails
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var pattern = @"(^|(?<=\s))[a-zA-Z0-9]+[\.\-_]?(?:[a-zA-Z0-9]+)@[a-zA-Z]+[-]?[a-zA-Z]+[.]{1}[a-zA-Z]+[.]*[a-zA-Z]+";

            var matches = Regex.Matches(input, pattern);

            foreach (Match match in matches)
            {
                Console.WriteLine(match);
            }
        }
    }
}
