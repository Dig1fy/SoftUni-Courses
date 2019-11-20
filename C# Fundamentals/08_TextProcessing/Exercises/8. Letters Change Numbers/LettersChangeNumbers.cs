using System;
using System.Linq;

namespace LettersChangeNumbers
{
    class Program
    {
        static void Main()
        {
            var alphabet = "abcdefghijklmnopqrstuvwxyz";

            var input = Console.ReadLine()
                .Split(new[] { " ", "\t" }, StringSplitOptions.RemoveEmptyEntries).ToList();

            var result = 0.0;
            var finalResult = 0.0;

            for (int i = 0; i < input.Count; i++)
            {
                result = 0.0;

                var firstLetter = input[i][0];
                var lastLetter = input[i][input[i].Length - 1];
                input[i] = input[i].Remove(0, 1);
                input[i] = input[i].Remove(input[i].Length - 1, 1);
                var digits = double.Parse(input[i]);

                if (char.IsUpper(firstLetter))
                {
                    var index = alphabet.ToUpper().IndexOf(firstLetter) + 1;
                    result += digits / index;
                }
                else 
                {
                    var index = alphabet.IndexOf(firstLetter) + 1;
                    result += (digits * index);
                }

                if (char.IsUpper(lastLetter))
                {
                    result -= ((alphabet.ToUpper().IndexOf(lastLetter) + 1));
                }
                else
                {
                    result += (alphabet.IndexOf(lastLetter) + 1);
                }

                finalResult += result;
            }

            Console.WriteLine($"{finalResult:f2}");
        }
    }
}
