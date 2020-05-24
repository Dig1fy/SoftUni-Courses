using System;

namespace NestedConditionalStatements
{
    class Program
    {
        static void Main()
        {
            string yearType = Console.ReadLine();
            double holidayCount = int.Parse(Console.ReadLine());
            int weekendHomeTrips = int.Parse(Console.ReadLine());

            int weekendsYear = 48;
            double gamesWeekendsSofia = (weekendsYear - weekendHomeTrips) * 0.75;   
            double gamesWeekendsHomeTown = weekendHomeTrips;
            double gamesInHolidays = holidayCount * 2 / 3;

            double totalGamesCountPerYear = gamesInHolidays + gamesWeekendsHomeTown + gamesWeekendsSofia;

            if (yearType == "leap")
            {
                totalGamesCountPerYear *= 1.15;

            }

            totalGamesCountPerYear = Math.Floor(totalGamesCountPerYear);
            Console.WriteLine(totalGamesCountPerYear);
        }
    }
}