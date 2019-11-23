using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            double visitors = double.Parse(Console.ReadLine());
            string activity = " ";

            double backTrainers = 0;
            double chestTrainers = 0;
            double legsTrainers = 0;
            double absTrainers = 0;
            double proteinShake = 0;
            double proteinBar = 0;

            double trainingPeople = 0;
            double proteinPeople = 0;


            for (int i = 0; i < visitors; i++)
            {
                activity = Console.ReadLine();

                if (activity == "Back")
                {
                    backTrainers++;
                    trainingPeople++;
                }
                else if (activity == "Chest")
                {
                    chestTrainers++;
                    trainingPeople++;
                }
                else if (activity == "Legs")
                {
                    legsTrainers++;
                    trainingPeople++;
                }
                else if (activity == "Abs")
                {
                    absTrainers++;
                    trainingPeople++;
                }
                else if (activity == "Protein shake")
                {
                    proteinShake++;
                    proteinPeople++;
                }
                else if (activity == "Protein bar")
                {
                    proteinBar++;
                    proteinPeople++;
                }
            }

            double percentageOfTrainers = trainingPeople / visitors * 100;
            double percentageOfProteinPpl = proteinPeople / visitors * 100;

            Console.WriteLine($"{backTrainers} - back");
            Console.WriteLine($"{chestTrainers} - chest");
            Console.WriteLine($"{legsTrainers} - legs");
            Console.WriteLine($"{absTrainers} - abs");
            Console.WriteLine($"{proteinShake} - protein shake");
            Console.WriteLine($"{proteinBar} - protein bar");
            Console.WriteLine($"{percentageOfTrainers:f2}% - work out");
            Console.WriteLine($"{percentageOfProteinPpl:f2}% - protein");
        }
    }
}