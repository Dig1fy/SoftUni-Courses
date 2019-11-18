using System;

namespace MiddleCharacters
{
    class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string middleCharacter = GetMiddleChar(input);
            Console.WriteLine(middleCharacter);
        }

        static string GetMiddleChar(string input)
        {
            if (input.Length % 2 == 0)
            {
                string result = input[input.Length / 2 - 1].ToString() + input[input.Length / 2].ToString();
                return result;
            }
            else
            {
                return input[input.Length / 2].ToString();
            }
        }
    }
}