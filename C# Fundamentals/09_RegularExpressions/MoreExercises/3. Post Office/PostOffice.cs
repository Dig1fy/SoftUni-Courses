using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PostOffice
{
    class Program
    {
        //90 out of 100 points in judge. The problem is most likely in the "thirdPart" append.  
        static void Main()
        {
            var input = Console.ReadLine().Split("|").ToArray();

            var firstPattern = @"([#$%*&]){1}(?<word>[A-Z]+)\1";
            var secondPattern = @"\d{2}:\d{2}";
            var allWordsInPartOne = string.Empty;

            var firstPart = input[0];
            var secondPart = input[1];
            var thirdPart = input[2]
                .Split()
                .ToArray();

            var firstMatches = Regex.Matches(firstPart, firstPattern);
            var secondMatches = Regex.Matches(secondPart, secondPattern);

            foreach (Match word in firstMatches)
            {
                allWordsInPartOne += word.Groups["word"].Value;
            }

            var listofChars = new List<Char>();

            foreach (Match symbol in secondMatches)
            {
                var symbols = symbol.Value
                    .Split(":")
                    .ToArray();

                var tempp = int.Parse(symbols[0]);
                var currentChar = (char)tempp;
                var additionalLength = int.Parse(symbols[1]);

                if (allWordsInPartOne.Contains(currentChar))
                {
                    Char tempCh = new Char();
                    tempCh.FirstChar = currentChar;
                    tempCh.Length = additionalLength + 1;
                    listofChars.Add(tempCh);
                }
            }

            var builder = new StringBuilder();

            for (int j = 0; j < thirdPart.Length; j++)
            {
                foreach (var letter in listofChars)
                {
                    if (letter.FirstChar == thirdPart[j][0] && thirdPart[j].Length == letter.Length)
                    {
                        builder.Append(thirdPart[j] + " ");

                    }
                }
            }

            var result = builder
                .ToString()
                .Split()
                .ToArray();
            var tempDict = new Dictionary<string, int>();

            foreach (var word in result)
            {
                if (!tempDict.ContainsKey(word))
                {
                    tempDict.Add(word, 1);
                }
            }

            Console.WriteLine(string.Join(Environment.NewLine, tempDict.Keys));
        }

        public class Char
        {
            public char FirstChar { get; set; }
            public int Length { get; set; }
        }
    }
}
