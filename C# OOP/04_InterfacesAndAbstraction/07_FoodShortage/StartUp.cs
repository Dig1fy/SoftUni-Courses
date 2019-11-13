namespace FoodShortage
{
    using FoodShortage.Contracts;
    using FoodShortage.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class StartUp
    {
        static void Main()
        {
            var numberOfInhabitants = int.Parse(Console.ReadLine());
            var listOfInhabitants = new List<IBuyer>();

            for (int loop = 0; loop < numberOfInhabitants; loop++)
            {
                var tokens = Console.ReadLine().Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                switch (tokens.Length)
                {
                    case 4:
                        var id = tokens[2];
                        listOfInhabitants.Add(new Citizen(name, age, id));
                        break;
                    case 3:
                        var group = tokens[2];
                        listOfInhabitants.Add(new Rebel(name, age, group));
                        break;
                    default:
                        break;
                }
            }

            var currentName = string.Empty;

            while ((currentName = Console.ReadLine()) != "End")
            {
                var buyer = listOfInhabitants.FirstOrDefault(x => x.Name == currentName);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(listOfInhabitants.Sum(x => x.Food));
        }
    }
}
