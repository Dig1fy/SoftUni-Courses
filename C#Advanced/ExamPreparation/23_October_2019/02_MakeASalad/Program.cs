namespace MakeASalad
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var inputVegetables = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var inputCalories = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var vegetables = new Queue<string>(inputVegetables);
            var calories = new Stack<int>(inputCalories);
            var salads = new List<int>();
            var currentCalories = 0;

            var tomatoValue = 80;
            var carrotValue = 136;
            var lettuceValue = 109;
            var potatoValue = 215;

            while (vegetables.Count > 0 && calories.Count > 0)
            {
                currentCalories = calories.Peek();
                var currentVegetable = vegetables.Dequeue();

                while (vegetables.Count > 0 && currentCalories > 0)
                {
                    switch (currentVegetable)
                    {
                        case "tomato": currentCalories -= tomatoValue; break;
                        case "carrot": currentCalories -= carrotValue; break;
                        case "lettuce": currentCalories -= lettuceValue; break;
                        case "potato": currentCalories -= potatoValue; break;
                        default:
                            break;
                    }

                    if (currentCalories <= 0)
                    {
                        salads.Add(calories.Pop());
                        break;
                    }
                    currentVegetable = vegetables.Dequeue();
                }
            }

            if (currentCalories > 0 && vegetables.Count == 0)
            {
                salads.Add(calories.Pop());
            }

            Console.WriteLine(string.Join(" ", salads));

            if (calories.Count > 0)
            {
                Console.WriteLine(string.Join(" ", calories));
            }

            if (vegetables.Count > 0)
            {
                Console.WriteLine(string.Join(" ", vegetables));
            }
        }
    }
}
