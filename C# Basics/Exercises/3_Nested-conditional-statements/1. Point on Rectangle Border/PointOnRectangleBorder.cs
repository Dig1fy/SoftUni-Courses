using System;

namespace NestedConditionalStatements
{
    class Program
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());

            bool onBorderX = (x == x1 || x == x2) && (y >= y1 && y <= y2);
            bool onBorderY = (y == y1 || y == y2) && (x >= x1 && x <= x2);

            if (onBorderX || onBorderY)
            {
                Console.WriteLine("Border");
            }
            else
            {
                Console.WriteLine("Inside / Outside");
            }
        }
    }
}