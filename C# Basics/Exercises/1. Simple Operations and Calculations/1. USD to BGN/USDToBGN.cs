using System;

namespace SimpleOperationsAndCalculations
{
    class Program
    {
        static void Main()
        {
            double dollar = double.Parse(Console.ReadLine());
            double BGN = dollar * 1.79549;
            Console.WriteLine($"{BGN:F2}");
        }
    }
}