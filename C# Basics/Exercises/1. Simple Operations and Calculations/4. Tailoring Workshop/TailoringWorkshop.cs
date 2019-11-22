using System;

namespace SimpleOperationsAndCalculations
{
    class Program
    {
        static void Main()
        {
            double tableNumber = double.Parse(Console.ReadLine());
            double tableLenght = double.Parse(Console.ReadLine());
            double tableWidth = double.Parse(Console.ReadLine());
            double areaRectangle = tableNumber * (tableLenght + 2 * 0.30) * (tableWidth + 2 * 0.30);
            double areaSquare = tableNumber * (tableLenght / 2) * (tableLenght / 2);
            double dollars = areaRectangle * 7 + areaSquare * 9;
            double BGN = dollars * 1.85;

            Console.WriteLine($"{dollars:F2} USD");
            Console.WriteLine($"{BGN:F2} BGN");
        }
    }
}