using System;

namespace VowelsCount
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            char[] inputArray = input.ToCharArray();
            int vowelCounter = 0;
            vowelCounter = GetNumberOfVowels(inputArray, vowelCounter);
        }

        private static int GetNumberOfVowels(char[] inputArray, int vowelCounter)
        {
            for (int i = 0; i < inputArray.Length; i++)
            {
                switch (inputArray[i])
                {
                    case 'i':
                    case 'o':
                    case 'u':
                    case 'e':
                    case 'a':
                    case 'A':
                    case 'I':
                    case 'O':
                    case 'U':
                    case 'E':
                        vowelCounter++;
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(vowelCounter);
            return vowelCounter;
        }
    }
}