using System;

namespace TriangleOfNumbers
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            for (int row = 1; row <= input; row++)
            {
                for (int col = 1; col <= row; col++)
                {
                    if (col != row)
                    {
                        Console.Write($"{row} ");
                    }
                    else
                    {
                        Console.Write($"{row}");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}