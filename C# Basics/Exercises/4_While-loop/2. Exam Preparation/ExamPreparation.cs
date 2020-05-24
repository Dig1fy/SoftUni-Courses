using System;

namespace WhileLoop
{
    class Program
    {
        static void Main()
        {
            int neededBadGrades = int.Parse(Console.ReadLine());
            int badGradesCounter = 0;
            int normalCounter = 0;

            string lastTask = "";
            string taskName = "";
            double allGrades = 0;
            bool isItEnough = false;

            while (badGradesCounter < neededBadGrades)
            {
                taskName = Console.ReadLine();

                if (taskName != "Enough")
                {
                    lastTask = taskName;
                }
                else
                {
                    isItEnough = true;
                    break;
                }

                int currentGrade = int.Parse(Console.ReadLine());

                if (currentGrade <= 4)
                {
                    badGradesCounter++;
                }
                allGrades += currentGrade;
                normalCounter++;
            }

            double averageGrade = allGrades / normalCounter;

            if (isItEnough)
            {
                Console.WriteLine($"Average score: {averageGrade:f2}");
                Console.WriteLine($"Number of problems: {normalCounter}");
                Console.WriteLine($"Last problem: {lastTask}");
            }
            else
                Console.WriteLine($"You need a break, {badGradesCounter} poor grades.");
        }
    }
}