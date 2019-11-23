using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            string playerName = Console.ReadLine();

            bool retire = false;
            int counter = 301;
            int successfulShots = 0;
            int unsuccessfulShots = 0;

            while (counter != 0)
            {
                string multiplier = Console.ReadLine();

                if (multiplier == "Retire")
                {
                    retire = true;
                    break;
                }

                int points = int.Parse(Console.ReadLine());

                if (multiplier == "Single")
                {
                    if (counter - points < 0)
                    {
                        unsuccessfulShots++;
                        continue;
                    }
                    else if (counter - points >= 0)
                    {
                        counter -= points;
                        successfulShots++;
                    }
                }
                else if (multiplier == "Double")
                {
                    if (counter - points * 2 < 0)
                    {
                        unsuccessfulShots++;
                        continue;
                    }
                    else if (counter - points * 2 >= 0)
                    {
                        counter -= points * 2;
                        successfulShots++;
                    }
                }
                else if (multiplier == "Triple")
                {
                    if (counter - points * 3 < 0)
                    {
                        unsuccessfulShots++;
                        continue;
                    }
                    else if (counter - points * 3 >= 0)
                    {
                        counter -= points * 3;
                        successfulShots++;
                    }
                }
            }

            if (retire)
            {
                Console.WriteLine($"{playerName} retired after {unsuccessfulShots} unsuccessful shots.");
            }
            else
            {
                Console.WriteLine($"{playerName} won the leg with {successfulShots} shots.");
            }
        }
    }
}