namespace SpaceshipCrafting
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        static void Main(string[] args)
        {
            var inputLiquids = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var inputPhisical = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var liquidItems = new Queue<int>(inputLiquids);
            var phisicalItems = new Stack<int>(inputPhisical);
            var outputCrafts = new Dictionary<string, int>();

            FillTheMaterials(outputCrafts);

            while (liquidItems.Count > 0 && phisicalItems.Count > 0)
            {
                var currentLiquid = liquidItems.Dequeue();
                var currentPhisical = phisicalItems.Pop();

                switch (currentPhisical + currentLiquid)
                {
                    case 25:
                        outputCrafts["Glass"]++;
                        break;
                    case 50:
                        outputCrafts["Aluminium"]++;
                        break;
                    case 75:
                        outputCrafts["Lithium"]++;
                        break;
                    case 100:
                        outputCrafts["Carbon fiber"]++;
                        break;
                    default:
                        phisicalItems.Push(currentPhisical + 3);
                        break;
                }
            }

            var sb = new StringBuilder();
            var isCrafted = true;

            foreach (var kvp in outputCrafts.OrderBy(x => x.Key))
            {
                sb.Append($"{kvp.Key}: ");
                sb.Append($"{kvp.Value}");
                sb.AppendLine();

                if (kvp.Value == 0)
                {
                    isCrafted = false;
                }
            }

            if (isCrafted)
                Console.WriteLine("Wohoo! You succeeded in building the spaceship!");
            else
                Console.WriteLine("Ugh, what a pity! You didn't have enough materials to build the spaceship.");


            if (liquidItems.Count > 0)
                Console.WriteLine($"Liquids left: {string.Join(", ", liquidItems)}");
            else
                Console.WriteLine("Liquids left: none");


            if (phisicalItems.Count > 0)
                Console.WriteLine($"Physical items left: {string.Join(", ", phisicalItems)}");
            else
                Console.WriteLine("Physical items left: none");

            Console.WriteLine(sb.ToString());
        }

        private static void FillTheMaterials(Dictionary<string, int> outputCrafts)
        {
            outputCrafts.Add("Glass", 0);
            outputCrafts.Add("Aluminium", 0);
            outputCrafts.Add("Lithium", 0);
            outputCrafts.Add("Carbon fiber", 0);
        }
    }
}
