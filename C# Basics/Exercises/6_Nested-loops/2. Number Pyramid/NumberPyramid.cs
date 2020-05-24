using System;

namespace NestedLoops
{
    class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int counter = 1;

            for (int row = 1; row <= n; row++)
            {
                for (int column = 1; column <= row; column++)
                {
                    if (counter > n)
                    {
                        break;
                    }

                    Console.Write(counter + " ");
                    counter++;
                }

                if (counter > n)
                {
                    break;
                }

                Console.WriteLine();
            }
        }
    }
}