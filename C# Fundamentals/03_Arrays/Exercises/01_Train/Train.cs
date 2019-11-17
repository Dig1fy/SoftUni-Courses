using System;

namespace Train
{
    class Program
    {
        static void Main()
        {
            int count = int.Parse(Console.ReadLine());
            int[] people = new int[count];
            int peopleCount = 0;

            for (int i = 0; i < count; i++)
            {
                int peopleInWagon = int.Parse(Console.ReadLine());
                people[i] = peopleInWagon;
                peopleCount += peopleInWagon;
            }

            for (int k = 0; k < people.Length; k++)
            {
                Console.Write($"{people[k]} ");
            }

            Console.WriteLine();
            Console.WriteLine(peopleCount);
        }
    }
}