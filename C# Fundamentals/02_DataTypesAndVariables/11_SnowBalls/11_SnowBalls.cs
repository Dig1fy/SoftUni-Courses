using System;
using System.Numerics;

namespace SnowBalls
{
    class Program
    {
        static void Main()
        {
            int bestSnowBallSnow = int.Parse(Console.ReadLine());
            BigInteger biggestSnowBallValue = 0;
            int bestTime = 0;
            int bestQuality = 0;

            int bestSnow = 0;

            for (int counts = 1; counts <= bestSnowBallSnow; counts++)
            {
                int snowballSnow = int.Parse(Console.ReadLine());
                int snowballTime = int.Parse(Console.ReadLine());
                int snowballQuality = int.Parse(Console.ReadLine());
                BigInteger snowballValue = BigInteger.Pow(snowballSnow / snowballTime, snowballQuality); ;

                if (snowballValue > biggestSnowBallValue)
                {
                    biggestSnowBallValue = snowballValue;
                    bestTime = snowballTime;
                    bestQuality = snowballQuality;
                    bestSnow = snowballSnow;
                }   
            }

            Console.WriteLine($"{bestSnow} : {bestTime} = {biggestSnowBallValue} ({bestQuality})");
        }
    }
}