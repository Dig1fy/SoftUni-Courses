using System;

namespace SimpleOperationsAndCalculations
{
    class Program
    {
        static void Main()
        {
            double wiskeyPricePerLiter = double.Parse(Console.ReadLine());
            double beerLitres = double.Parse(Console.ReadLine());
            double wineLitres = double.Parse(Console.ReadLine());
            double rakiaLitres = double.Parse(Console.ReadLine());
            double wiskeyLitres = double.Parse(Console.ReadLine());

            double rakiaPricePerLiter = (wiskeyPricePerLiter - (0.5 * wiskeyPricePerLiter));
            double winePricePerLiter = (rakiaPricePerLiter - (0.4 * rakiaPricePerLiter));
            double beerPricePerLiter = (rakiaPricePerLiter - (0.8 * rakiaPricePerLiter));

            double wiskeyPriceTotal = wiskeyPricePerLiter * wiskeyLitres;
            double rakiaPriceTotal = rakiaLitres * rakiaPricePerLiter;
            double winePriceTotal = winePricePerLiter * wineLitres;
            double beerPriceTotal = beerPricePerLiter * beerLitres;

            double totalPrice = wiskeyPriceTotal + rakiaPriceTotal + winePriceTotal + beerPriceTotal;
            Console.WriteLine($"{totalPrice:F2}");
        }
    }
}