using System;

namespace NestedConditionalStatements
{
    class Program
    {
        static void Main()
        {
            string typeOfFlowers = Console.ReadLine();
            int flowersQY = int.Parse(Console.ReadLine());
            int budget = int.Parse(Console.ReadLine());

            double roses = 5;
            double dahlias = 3.80;
            double tulips = 2.80;
            double narcissus = 3;
            double gladiolus = 2.50;

            double price = 0;

            if (typeOfFlowers == "Roses")
            {
                if (flowersQY > 80)
                {
                    price = roses * flowersQY * 0.9;
                }
                else
                {
                    price = roses * flowersQY;
                }
            }
            else if (typeOfFlowers == "Dahlias")
            {
                if (flowersQY > 90)
                {
                    price = dahlias * flowersQY * 0.85;
                }
                else
                {
                    price = dahlias * flowersQY;
                }
            }
            else if (typeOfFlowers == "Tulips")
            {
                if (flowersQY > 80)
                {
                    price = tulips * flowersQY * 0.85;
                }
                else
                {
                    price = tulips * flowersQY;
                }
            }
            else if (typeOfFlowers == "Narcissus")
            {
                if (flowersQY < 120)
                {
                    price = narcissus * flowersQY * 1.15;
                }
                else
                {
                    price = narcissus * flowersQY;
                }
            }
            else if (typeOfFlowers == "Gladiolus")
            {
                if (flowersQY < 80)
                {
                    price = gladiolus * flowersQY * 1.20;
                }
                else
                {
                    price = gladiolus * flowersQY;
                }
            }

            if (budget >= price)
            {
                Console.WriteLine($"Hey, you have a great garden with {flowersQY} {typeOfFlowers} and {(budget - price):F2} leva left.");
            }
            else
            {
                Console.WriteLine($"Not enough money, you need {Math.Abs(budget - price):F2} leva more.");
            }
        }
    }
}