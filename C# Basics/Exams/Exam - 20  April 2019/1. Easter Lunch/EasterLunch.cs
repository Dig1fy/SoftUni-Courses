using System;

namespace ExamOn20April2019
{
    class Program
    {
        static void Main()
        {
            int kozunakQy = int.Parse(Console.ReadLine());
            int eggsQy = int.Parse(Console.ReadLine());
            int coockiesQy = int.Parse(Console.ReadLine());

            double kozunakPrice = 3.20;
            double eggsPrice = 4.35;
            double coockiesPrice = 5.40;
            double paintPerEgg = 0.15;
            double paintSum = paintPerEgg * 12 * eggsQy;

            double kozunakTotal = kozunakPrice * kozunakQy;
            double eggsTotal = eggsPrice * eggsQy;
            double coockiesTotal = coockiesQy * coockiesPrice;

            double totalSum = kozunakTotal + eggsTotal + coockiesTotal + paintSum;

            Console.WriteLine($"{totalSum:f2}");
        }
    }
}