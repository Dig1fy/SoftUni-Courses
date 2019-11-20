using System;

namespace StringExplosion
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
            var divided = input.Split(">");

            int explosion = 0;
            int remainingExplosion = 0;

            for (int i = 1; i < divided.Length; i++)
            {
                explosion = divided[i][0] - '0' + remainingExplosion;
                remainingExplosion = divided[i][0] - '0' - divided[i].Length;

                if (explosion > divided[i].Length)
                {
                    explosion = divided[i].Length;
                }

                divided[i] = divided[i].Substring(explosion);

                if (remainingExplosion < 0)
                {
                    remainingExplosion = 0;
                }
            }

            var result = string.Join(">", divided);
            Console.WriteLine(result);
        }
    }
}
