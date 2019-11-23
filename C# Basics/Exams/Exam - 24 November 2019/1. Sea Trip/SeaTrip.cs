using System;

namespace Exam24November2019
{
    class Program
    {
        static void Main()
        {
            double moneyPerDay = double.Parse(Console.ReadLine());
            double moneyForSouvenirs = double.Parse(Console.ReadLine());
            double moneyForHotel = double.Parse(Console.ReadLine());

            double moneyForGazolineEE = (420.00 / 100.00);
            double moneyForGazolineE = moneyForGazolineEE * 7;
            double moneyForGazoline = moneyForGazolineE * 1.85;
            double moneyFoodAndSouvenirs = 3 * (moneyForSouvenirs + moneyPerDay);
            double moneyForHotelTotal = moneyForHotel * 0.9 + moneyForHotel * 0.85 + moneyForHotel * 0.8;

            double totalSum = moneyForHotelTotal + moneyFoodAndSouvenirs + moneyForGazoline;

            Console.WriteLine($"Money needed: {totalSum:f2}");
        }
    }
}