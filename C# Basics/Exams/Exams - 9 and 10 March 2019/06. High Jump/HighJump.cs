using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            int desiredHight = int.Parse(Console.ReadLine());

            int nextAttempt = desiredHight - 30;
            int fails = 0;
            int attempts = 0;
            bool success = false;

            while (!success)
            {
                attempts++;
                int currentTry = int.Parse(Console.ReadLine());

                if (currentTry <= nextAttempt)
                {
                    fails++;

                    if (fails == 3)
                    {
                        Console.WriteLine($"Tihomir failed at {nextAttempt}cm after {attempts} jumps.");
                        break;
                    }
                }
                else
                {
                    if (currentTry > nextAttempt && nextAttempt >= desiredHight)
                    {
                        Console.WriteLine($"Tihomir succeeded, he jumped over {nextAttempt}cm after {attempts} jumps.");
                        break;
                    }

                    nextAttempt += 5;
                    fails = 0;
                }
            }
        }
    }
}