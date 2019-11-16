using System;

namespace PrintAndSum
{
    class Program
    {
        static void Main()
        {
            int firstNum = int.Parse(Console.ReadLine());
            int lastNum = int.Parse(Console.ReadLine());
            int sum = 0;

            for (int i = firstNum; i <= lastNum; i++)
            {
                sum += i;
                if (i == lastNum)
                {
                    Console.Write($"{i}");
                }
                else
                {
                    Console.Write($"{i} ");
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Sum: {sum}");
        }
    }
}
