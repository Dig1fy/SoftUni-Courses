using System;

namespace ExamOn09And10March2019
{
    class Program
    {
        static void Main()
        {
            int currentMatchCount = 0;
            int totalMatchCounts = 0;
            string tournamentName = "";
            double matchesLost = 0;
            double matchesWon = 0;

            while (tournamentName != "End of tournaments")
            {
                tournamentName = Console.ReadLine();

                if (tournamentName == "End of tournaments")
                {
                    Console.WriteLine($"{(matchesWon / totalMatchCounts * 100):f2}% matches win");
                    Console.WriteLine($"{(matchesLost / totalMatchCounts * 100):f2}% matches lost");
                    return;
                }

                currentMatchCount = int.Parse(Console.ReadLine());
                totalMatchCounts += currentMatchCount;

                for (int i = 1; i <= currentMatchCount; i++)
                {
                    double pointsDesi = double.Parse(Console.ReadLine());
                    double pointsEnemy = double.Parse(Console.ReadLine());

                    if (pointsDesi > pointsEnemy)
                    {
                        Console.WriteLine($"Game {i} of tournament {tournamentName}: win with {pointsDesi - pointsEnemy} points.");
                        matchesWon++;
                    }
                    else
                    {
                        Console.WriteLine($"Game {i} of tournament {tournamentName}: lost with {pointsEnemy - pointsDesi} points.");
                        matchesLost++;
                    }
                }
            }
        }
    }
}