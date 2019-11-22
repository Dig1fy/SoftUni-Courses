using System;

namespace SimpleOperationsAndCalculations
{
    class Program
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double lenght = Math.Abs(x1 - x2);
            double width = Math.Abs(y1 - y2);
            double Area = lenght * width;
            double Perimeter = 2 * (lenght + width);
            Console.WriteLine($"{Area:F2}");
            Console.WriteLine($"{Perimeter:F2}");
        }
    }
}