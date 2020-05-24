using System;

namespace WhileLoop
{
    class Program
    {
        static void Main()
        {
            int goal = 10000;
            int totalSteps = 0;

            while (totalSteps < goal)
            {
                string currentSteps = Console.ReadLine();

                if (currentSteps == "Going home")
                {
                    totalSteps += int.Parse(Console.ReadLine());
                    break;
                }
                else
                {
                    totalSteps += int.Parse(currentSteps);
                }
            }

            if (totalSteps >= goal)
            {
                Console.WriteLine($"Goal reached! Good job!");
            }
            else
            {
                Console.WriteLine($"{goal - totalSteps} more steps to reach goal.");
            }
        }
    }
}