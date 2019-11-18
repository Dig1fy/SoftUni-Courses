using System;

namespace SmallestOfThreeNumbers
{
    class Program
    {
        static void Main()
        {
            int first = int.Parse(Console.ReadLine());
            int second = int.Parse(Console.ReadLine());
            int third = int.Parse(Console.ReadLine());
            int minNumber = GetSmallestNumber(first, second, third);
            Console.WriteLine(minNumber);
        }

        static int GetSmallestNumber(int first, int second, int third)

        {
            return Math.Min(first, Math.Min(second, third));
        }
    }
}