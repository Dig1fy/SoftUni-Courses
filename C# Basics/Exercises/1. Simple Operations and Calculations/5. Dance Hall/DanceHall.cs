using System;

namespace SimpleOperationsAndCalculations
{
    class Program
    {
        static void Main()
        {
            double hallLenght = double.Parse(Console.ReadLine()) * 100;
            double hallWidth = double.Parse(Console.ReadLine()) * 100;
            double wardrobeSide = double.Parse(Console.ReadLine()) * 100;

            double hallArea = hallLenght * hallWidth;
            double wardrobeArea = wardrobeSide * wardrobeSide;
            double bench = hallArea / 10;
            double hallFreeSpace = hallArea - wardrobeArea - bench;

            double dancerNeededSpace = 7000 + 40;
            double dancersCount = hallFreeSpace / dancerNeededSpace;

            Console.WriteLine(Math.Floor(dancersCount));
        }
    }
}