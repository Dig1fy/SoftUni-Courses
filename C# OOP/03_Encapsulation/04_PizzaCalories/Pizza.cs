namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private string name;
        private Dough dough;
        private const int minPizzaNameLength = 1;
        private const int maxPizzaNameLength = 15;

        public Pizza(string name)
        {
            this.Name = name;
            this.Toppings = new List<Topping>();
        }

        private List<Topping> Toppings { get; }

        private string Name
        {
            get { return name; }
            set
            {
                if (value.Length < minPizzaNameLength
                    || value.Length > maxPizzaNameLength
                    || string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                name = value;
            }
        }
        private Dough Dough { get; set; }

        public string GetPizzasName()
        {
            return this.Name ;
        }
        public void ChoocePizzasDough(Dough dough)
        {
            this.Dough = dough;
        }
        public void AddTopping(Topping topping)
        {
            if (this.Toppings.Count >= 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.Toppings.Add(topping);
        }

        public double GetTotalCalories()
        {
            var totalToppingCalories = 0.0;
            var totalDoughCalories = this.Dough.GetDoughCalories();

            foreach (var topping in Toppings)
            {
                totalToppingCalories += topping.GetToppingCalories();
            }

            return totalToppingCalories + totalDoughCalories; ;
        }
    }
}
