using System;

namespace VendingMachine
{
    class Program
    {
        static void Main()
        {
            double nutsPrice = 2.0;
            double waterPrice = 0.7;
            double crispsPrice = 1.5;
            double sodaPrice = 0.8;
            double cokePrice = 1.0;
            double price = 0;

            string command = string.Empty;
            string product = string.Empty;
            double inputCoins = 0;
            double inputSum = 0;

            while ((command = Console.ReadLine()) != "Start")
            {
                inputCoins = double.Parse(command);

                switch (inputCoins)
                {
                    case 0.1:
                    case 0.2:
                    case 0.5:
                    case 1.0:
                    case 2.0:

                        inputSum += inputCoins;
                        break;
                    default:
                        Console.WriteLine($"Cannot accept {inputCoins}");
                        break;
                }
            }

            while ((product = Console.ReadLine()) != "End")
            {
                if (product == "Nuts")
                {
                    price = nutsPrice;
                }
                else if (product == "Water")
                {
                    price = waterPrice;
                }
                else if (product == "Crisps")
                {
                    price = crispsPrice;
                }
                else if (product == "Soda")
                {
                    price = sodaPrice;
                }
                else if (product == "Coke")
                {
                    price = cokePrice;
                }
                else
                {
                    Console.WriteLine("Invalid product");
                    continue;
                }
                if (inputSum - price >= 0)
                {
                    inputSum -= price;
                    Console.WriteLine($"Purchased {product.ToLower()}");
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }
            }

            Console.WriteLine($"Change: {inputSum:f2}");
        }
    }
}