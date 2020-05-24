using System;

namespace WhileLoop
{
    class Program
    {
        static void Main()
        {
            decimal change = decimal.Parse(Console.ReadLine()) * 100;
            double counter = 0;
            decimal currentChange = 0;

            while (currentChange < change)
            {
                if (change >= currentChange + 200)
                {
                    currentChange += 200;
                    counter++;
                }
                else if (change >= currentChange + 100)
                {
                    currentChange += 100;
                    counter++;
                }
                else if (change >= currentChange + 50)
                {
                    currentChange += 50;
                    counter++;
                }
                else if (change >= currentChange + 20)
                {
                    currentChange += 20;
                    counter++;
                }
                else if (change >= currentChange + 10)
                {
                    currentChange += 10;
                    counter++;
                }
                else if (change >= currentChange + 5)
                {
                    currentChange += 5;
                    counter++;
                }
                else if (change >= currentChange + 2)
                {
                    currentChange += 2;
                    counter++;
                }
                else if (change >= currentChange + 1)
                {
                    currentChange += 1;
                    counter++;
                }
            }

            Console.WriteLine(counter);
        }
    }
}