using System;

namespace TriplesOfLatinLetters
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 0; i < input; i++)
            {
                char firstChar = (char)('a' + i);

                for (int j = 0; j < input; j++)
                {
                    char secondChar = (char)('a' + j);
                    for (int k = 0; k < input; k++)
                    {
                        char thirdChar = (char)('a' + k);
                        Console.WriteLine($"{firstChar}{secondChar}{thirdChar}");
                    }
                }
            }
        }
    }
}