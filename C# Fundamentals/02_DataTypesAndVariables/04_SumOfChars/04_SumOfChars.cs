using System;

namespace SumOfChars
{
    class Program
    {
        static void Main()
        {
            int numberOfLines = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int index = 1; index <= numberOfLines; index++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                sum += (int)(currentChar);
            }

            Console.WriteLine($"The sum equals: {sum}");
        }
    }
}