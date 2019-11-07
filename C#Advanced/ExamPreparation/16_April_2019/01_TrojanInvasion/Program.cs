namespace TrojanInvasion
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var waves = int.Parse(Console.ReadLine());
            var plates = Console.ReadLine().Split().Select(int.Parse).ToList();
            var trojans = new Stack<int>();

            for (int i = 1; i <= waves; i++)
            {
                if (plates.Count == 0)
                {
                    break;
                }

                trojans = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToList());

                if (i % 3 == 0)
                {
                    plates.Add(int.Parse(Console.ReadLine()));
                }

                while (plates.Count > 0 && trojans.Count > 0)
                {

                    var compare = plates[0].CompareTo(trojans.Peek());

                    switch (compare)
                    {
                        case 0:
                            plates.RemoveAt(0);
                            trojans.Pop();
                            break;
                        case 1:
                            plates[0] -= trojans.Pop();
                            break;
                        case -1:
                            trojans.Push(trojans.Pop() - plates[0]);
                            plates.RemoveAt(0);
                            break;
                        default:
                            break;
                    }
                }
            }

            if (plates.Count == 0)
            {
                Console.WriteLine("The Trojans successfully destroyed the Spartan defense.");
                Console.WriteLine($"Warriors left: {string.Join(", ", trojans)}");
            }
            else
            {
                Console.WriteLine("The Spartans successfully repulsed the Trojan attack.");
                Console.WriteLine($"Plates left: {string.Join(", ", plates)}");
            }
        }
    }
}
