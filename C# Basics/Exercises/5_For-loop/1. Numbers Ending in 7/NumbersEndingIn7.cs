using System;

namespace ForLoop
{
    class Program
    {
        static void Main()
        {
            int n = 1000;

            for (int i = 0; i <= n; i++)
            {
                if (i % 10 == 7)
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}