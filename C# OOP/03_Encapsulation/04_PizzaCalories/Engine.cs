namespace PizzaCalories
{
    using System;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            try
            {
                var pizzaName = Console.ReadLine().Split().Skip(1).First();
                var pizza = new Pizza(pizzaName);
                var doughInfo = Console.ReadLine()
                    .ToLower()
                    .Split()
                    .Skip(1)
                    .ToArray();

                var type = doughInfo[0];
                var technique = doughInfo[1];
                var grams = int.Parse(doughInfo[2]);
                var dough = new Dough(type, technique, grams);
                
                pizza.ChoocePizzasDough(dough);

                var command = string.Empty;
                while ((command = Console.ReadLine()) != "END")
                {
                    var toppingInfo = command
                    .ToLower()
                    .Split()
                    .Skip(1)
                    .ToArray();

                    var toppingType = toppingInfo[0];
                    var toppingGrams = int.Parse(toppingInfo[1]);
                    var topping = new Topping(toppingType, toppingGrams);
                    pizza.AddTopping(topping);
                    
                }

                Console.WriteLine($"{pizza.GetPizzasName()} - {pizza.GetTotalCalories():F2} Calories.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
