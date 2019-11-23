using System;

namespace Exam24November2019
{
    class Program
    {
        static void Main()
        {
            int num = int.Parse(Console.ReadLine());
            int first = num % 10;
            int second = num / 10 % 10;
            int third = num / 100 % 10;

            for (int _1 = 1; _1 <= first; _1++)
            {
                for (int _2 = 1; _2 <= second; _2++)
                {
                    for (int _3 = 1; _3 <= third; _3++)
                    {
                        Console.WriteLine($"{_1} * {_2} * {_3} = {_1 * _2 * _3};");
                    }
                }
            }
        }
    }
}