using System;

namespace PokeMon
{
    class Program
    {
        static void Main()
        {
            int N = int.Parse(Console.ReadLine());
            int initialN = N;
            int M = int.Parse(Console.ReadLine());
            int pokePowerDivided = N / 2;
            int Y = int.Parse(Console.ReadLine());
            int pokeCounts = 0;

            while (M <= N)
            {
                pokeCounts++;
                N -= M;

                if (N == pokePowerDivided)
                {
                    if (Y != 0 && N / Y > 0)
                    {
                        N /= Y;
                    }
                    else
                    {
                        continue;
                    }
                }
            }

            Console.WriteLine(N);
            Console.WriteLine(pokeCounts);
        }
    }
}