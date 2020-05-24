using System;

namespace NestedLoops
{
    class Program
    {
        static void Main()
        {
            string N = Console.ReadLine();
            int num = int.Parse(N);
            int counter = 0;

            for (int i = 1111; i <= 9999; i++)
            {
                int whileCounter = 0;
                counter = 0;
                int newValueOfNumber = i;

                while (whileCounter < 5)
                {
                    int module = newValueOfNumber % 10;

                    if (module == 0)
                    {
                        break;
                    }

                    int realModule = num % module;

                    if (realModule == 0)
                    {
                        counter++;
                    }

                    newValueOfNumber /= 10;

                    if (counter == 4)
                    {
                        Console.Write(i + " ");
                        break;
                    }
                }
            }
        }
    }
}