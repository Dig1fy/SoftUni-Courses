namespace SummerCocktails
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var inputIngredients = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var inputRefreshness = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var ingredients = new Queue<int>(inputIngredients);
            var refreshnessLevels = new Stack<int>(inputRefreshness);

            var cocktails = new Dictionary<string, int>
            {
                { "Mimosa", 0 },
                { "Daiquiri", 0 },
                { "Sunshine", 0 },
                { "Mojito", 0 }
            };

            const int mimosaValue = 150;
            const int daiquiriValue = 250;
            const int sunshineValue = 300;
            const int mojitoValue = 400;

            while (ingredients.Count > 0 && refreshnessLevels.Count > 0)
            {
                var currentIngredient = ingredients.Dequeue();
                var currentRefreshness = refreshnessLevels.Pop();

                if (currentIngredient.Equals(0))
                {
                    if (ingredients.Count > 0)
                    {
                        while (currentIngredient.Equals(0) && ingredients.Count > 0)
                        {
                            currentIngredient = ingredients.Dequeue();
                        }
                    }
                    else
                    {
                        refreshnessLevels.Push(currentRefreshness);
                        break;
                    }

                }
                switch (currentIngredient * currentRefreshness)
                {
                    case mimosaValue:
                        cocktails["Mimosa"]++;
                        break;
                    case daiquiriValue:
                        cocktails["Daiquiri"]++;
                        break;
                    case sunshineValue:
                        cocktails["Sunshine"]++;
                        break;
                    case mojitoValue:
                        cocktails["Mojito"]++;
                        break;
                    default:
                        ingredients.Enqueue(currentIngredient + 5);
                        break;
                }
            }

            var isPartyTime = cocktails.ContainsValue(0);

            if (isPartyTime)
            {
                Console.WriteLine($"What a pity! You didn't manage to prepare all cocktails.");
            }
            else
            {
                Console.WriteLine($"It's party time! The cocktails are ready!");

            }
            if (ingredients.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredients.Sum()}");
            }

            foreach (var cocktail in cocktails.Where(x => x.Value != 0).OrderBy(c => c.Key))
            {
                Console.WriteLine($"# {cocktail.Key} --> {cocktail.Value}");
            }
        }
    }
}
