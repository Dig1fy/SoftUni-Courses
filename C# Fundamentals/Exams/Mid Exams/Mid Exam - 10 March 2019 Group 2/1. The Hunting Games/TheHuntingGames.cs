using System;

namespace TheHuntingGames
{
    class Program
    {
        static void Main()
        {
            int days = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupsEnergy = double.Parse(Console.ReadLine());
            double groupsWater = double.Parse(Console.ReadLine()) * players * days;
            double groupsFood = double.Parse(Console.ReadLine()) * players * days;

            bool isEnergyEnough = true;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());

                if (groupsEnergy - energyLoss <= 0)
                {
                    isEnergyEnough = false;
                    break;
                }
                else
                {
                    groupsEnergy -= energyLoss;
                }

                if (i % 2 == 0)
                {
                    groupsEnergy *= 1.05;
                    groupsWater *= 0.7;
                }

                if (i % 3 == 0)
                {
                    groupsFood -= groupsFood / players;
                    groupsEnergy *= 1.1;
                }
            }

            if (isEnergyEnough)
            {
                Console.WriteLine($"You are ready for the quest. You will be left with - {groupsEnergy:f2} energy!");
            }
            else
            {
                Console.WriteLine($"You will run out of energy. You will be left with {groupsFood:f2} food and {groupsWater:f2} water.");

            }
        }
    }
}
