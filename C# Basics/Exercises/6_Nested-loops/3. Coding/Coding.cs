using System;

namespace NestedLoops
{
    class Program
    {
        static void Main()
        {
            string consoleInput = Console.ReadLine();

            for (int num = consoleInput.Length - 1; num >= 0; num--)
            {
                char chopped = consoleInput[num];
                int numbers = int.Parse(chopped.ToString());

                if (numbers == 0)
                {
                    Console.Write("ZERO");
                }
                else
                {
                    for (int i = numbers; i > 0; i--)
                    {
                        Console.Write((char)(numbers + 33));
                    }
                }

                Console.WriteLine();
            }
        }
    }
}