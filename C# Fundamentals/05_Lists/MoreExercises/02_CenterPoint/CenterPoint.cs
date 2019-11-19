using System;

namespace CenterPoint
{
    class Program
    {
        static void Main()
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            GetClosestPointToZero(x1, y1, x2, y2);
        }

        static void GetClosestPointToZero(double x1, double y1, double x2, double y2)
        {
            double firstResult = Math.Abs(x1) + Math.Abs(y1);
            double secondResult = Math.Abs(x2) + Math.Abs(y2);

            if (firstResult <= secondResult)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else if (firstResult > secondResult)
            {
                Console.WriteLine($"({x2}, {y2})"); ;
            }
        }
    }
}