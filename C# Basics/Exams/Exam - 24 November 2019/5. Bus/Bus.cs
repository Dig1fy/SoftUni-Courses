using System;

namespace Exam24November2019
{
    class Program
    {
        static void Main()
        {
            int passengersStart = int.Parse(Console.ReadLine());
            int busStops = int.Parse(Console.ReadLine());

            for (int i = 1; i <= busStops; i++)
            {
                int getOut = int.Parse(Console.ReadLine());
                passengersStart -= getOut;
                int getIn = int.Parse(Console.ReadLine());
                passengersStart += getIn;

                if (i % 2 != 0)
                {
                    passengersStart += 2;
                }
                else
                {
                    passengersStart -= 2;
                }
            }

            Console.WriteLine($"The final number of passengers is : {passengersStart}");
        }
    }
}