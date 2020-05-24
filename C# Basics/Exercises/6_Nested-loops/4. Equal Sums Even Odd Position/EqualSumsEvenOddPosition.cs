using System;

namespace NestedLoops
{
    class Program
    {
        static void Main()
        {
            string smaller = Console.ReadLine();
            string bigger = Console.ReadLine();

            for (int i = int.Parse(smaller); i <= int.Parse(bigger); i++)
            {
                string num = i.ToString();
                int length = num.Length;

                int evenSum = 0;
                int oddSum = 0;
                int process = i;
                
                for (int ii = 1; ii <= length; ii++)
                {
                    int modul = process % 10;

                    if ((ii) % 2 == 0)
                    {
                        evenSum += modul;
                    }
                    else
                    {
                        oddSum += modul;
                    }

                    process = (process - modul) / 10;
                }

                if (oddSum == evenSum)
                {
                    Console.Write(i + " ");

                }
            }
        }
    }
}