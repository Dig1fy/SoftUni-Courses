using System;

namespace NestedConditionalStatements
{
    class Program
    {
        static void Main()
        {
            string month = Console.ReadLine();
            int nightsCount = int.Parse(Console.ReadLine());

            double mayOctoberStudio = 50;
            double mayOctoberApartment = 65;
            double juneSeptemberStudio = 75.20;
            double juneSeptemberApartment = 68.70;
            double julyAugustStudio = 76;
            double julyAugustApartment = 77;

            double priceApartment = 0;
            double priceStudio = 0;

            if (month == "May" || month == "October")
            {
                if (nightsCount <= 7)
                {
                    priceStudio = mayOctoberStudio * nightsCount;
                    priceApartment = nightsCount * mayOctoberApartment;
                }
                else if (nightsCount > 7 && nightsCount <= 14)
                {
                    priceStudio = mayOctoberStudio * nightsCount * 0.95;
                    priceApartment = nightsCount * mayOctoberApartment;
                }

                if (nightsCount > 14)
                {
                    priceApartment = nightsCount * mayOctoberApartment * 0.9;
                    priceStudio = mayOctoberStudio * nightsCount * 0.7;
                }

            }
            else if (month == "June" || month == "September")
            {
                if (nightsCount <= 14)
                {
                    priceStudio = juneSeptemberStudio * nightsCount;
                    priceApartment = nightsCount * juneSeptemberApartment;
                }
                else if (nightsCount > 14)
                {
                    priceApartment = juneSeptemberApartment * nightsCount * 0.9;
                    priceStudio = juneSeptemberStudio * nightsCount * 0.8;
                }
            }
            else if (month == "July" || month == "August")
            {
                if (nightsCount > 14)
                {
                    priceApartment = julyAugustApartment * nightsCount * 0.9;
                }
                else
                {
                    priceApartment = julyAugustApartment * nightsCount;
                }

                priceStudio = julyAugustStudio * nightsCount;
            }

            Console.WriteLine($"Apartment: {priceApartment:f2} lv.");
            Console.WriteLine($"Studio: {priceStudio:f2} lv.");
        }
    }
}