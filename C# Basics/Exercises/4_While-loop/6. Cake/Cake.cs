using System;

namespace WhileLoop
{
    class Program
    {
        static void Main()
        {
            int cakeWidth = int.Parse(Console.ReadLine());
            int cakeLength = int.Parse(Console.ReadLine());

            int cakeArea = cakeWidth * cakeLength;
            bool isItNumber = false;
            int pieces = 0;

            while (pieces <= cakeArea)
            {
                string command = Console.ReadLine();

                if (command != "STOP")
                {
                    pieces += int.Parse(command);

                }
                else
                {
                    isItNumber = true;
                    break;
                }
            }

            if (isItNumber)
            {
                Console.WriteLine($"{cakeArea - pieces} pieces are left.");
            }
            else
            {
                Console.WriteLine($"No more cake left! You need {Math.Abs(pieces - cakeArea)} pieces more.");
            }
        }
    }
}