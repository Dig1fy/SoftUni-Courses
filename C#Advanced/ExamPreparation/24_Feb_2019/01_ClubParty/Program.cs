namespace ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());

            var input = Console.ReadLine()
                .Split()
                .ToArray();

            var allHallsAndPeople = new Stack<string>(input);
            var halls = new Queue<char>();
            var currentCount = new List<int>();

            while (allHallsAndPeople.Count > 0)
            {
                var currentHallOrPeople = allHallsAndPeople.Pop();
                var isItGroup = int.TryParse(currentHallOrPeople, out int group);

                if (!isItGroup)
                {
                    halls.Enqueue(char.Parse(currentHallOrPeople));
                    continue;
                }

                if (isItGroup && halls.Count == 0)
                {
                    continue;
                }
                else if (isItGroup && halls.Count > 0)
                {
                    if (currentCount.Sum() + group <= maxCapacity)
                    {                        
                        currentCount.Add(group);
                    }                    
                    else if (currentCount.Sum() + group > maxCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", currentCount)}");
                        currentCount.Clear();
                        allHallsAndPeople.Push(group.ToString());
                    }
                }
            }
        }
    }
}
