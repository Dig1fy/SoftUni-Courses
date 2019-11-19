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
            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double firstLine = GetFirstLineLength(x1, y1, x2, y2);
            double secondLine = GetSecondLineLength(x3, y3, x4, y4);

            if (firstLine >= secondLine)
            {
                GetClosestPointToZero(x1, y1, x2, y2);
            }
            else
            {
                GetClosestPointToZero(x3, y3, x4, y4);
            }
        }

        static double GetFirstLineLength(double x1, double y1, double x2, double y2)
        {
            double lineLength = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return lineLength;
        }
        static double GetSecondLineLength(double x3, double y3, double x4, double y4)
        {
            double lineLength = Math.Sqrt((x4 - x3) * (x4 - x3) + (y4 - y3) * (y4 - y3));
            return lineLength;
        }
        static void GetClosestPointToZero(double x1, double y1, double x2, double y2)
        {
            double firstResult = Math.Abs(x1) + Math.Abs(y1);
            double secondResult = Math.Abs(x2) + Math.Abs(y2);

            if (firstResult <= secondResult)
            {
                Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
            }
            else if (firstResult > secondResult)
            {
                Console.WriteLine($"({x2}, {y2})({x1}, {y1})"); ;
            }
        }
    }
}