using System;
using System.Linq;

namespace CharacterMultiplier
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine()
                .Split()
                .ToArray();

            var firstWord = input[0];
            var secondWord = input[1];
            var sum = 0;

            if (firstWord.Length == secondWord.Length)
            {
                sum += GetSumOfWords(firstWord, secondWord);
            }
            else
            {

                var longerWord = string.Empty;
                longerWord = firstWord.Length > secondWord.Length ? longerWord = firstWord : longerWord = secondWord;

                var shorterWord = string.Empty;
                shorterWord = firstWord.Length < secondWord.Length ? shorterWord = firstWord : shorterWord = secondWord;

                for (int i = 0; i < shorterWord.Length; i++)
                {
                    sum += shorterWord[i] * longerWord[i];
                }

                for (int i = shorterWord.Length; i < longerWord.Length; i++)
                {
                    sum += longerWord[i];
                }
            }

            Console.WriteLine(sum);
        }

        static int GetSumOfWords(string first, string second)
        {
            var sum = 0;

            for (int i = 0; i < first.Length; i++)
            {
                sum += first[i] * second[i];
            }

            return sum;
        }
    }
}
