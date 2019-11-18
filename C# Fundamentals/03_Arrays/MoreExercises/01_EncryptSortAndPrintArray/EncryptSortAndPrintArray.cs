using System;
using System.Linq;

namespace EncryptSortAndPrintArray
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());
            int currentSum = 0;
            int[] newValues = new int[input];
            string vowels = "aAoOuUeEiI";
            char[] vowelsArray = vowels.ToCharArray();

            for (int i = 0; i < input; i++)
            {
                string words = Console.ReadLine();
                char[] currentInput = words.ToCharArray();
                for (int j = 0; j < words.Length; j++)
                {
                    char currentChar = words[j];
                    if (vowelsArray.Contains(currentChar))
                    {
                        currentSum += (int)currentChar * words.Length;
                    }
                    else
                    {
                        currentSum += currentChar / words.Length;
                    }
                }

                newValues[i] = currentSum;
                currentSum = 0;
            }

            Array.Sort(newValues);

            foreach (var num in newValues)
            {
                Console.WriteLine(num);
            }
        }
    }
}