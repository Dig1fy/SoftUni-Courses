namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Topping
    {
        private string type;
        private int grams;
        private Dictionary<string, double> modifiers;
        const int maxValue = 50;
        const int minValue = 1;

        public Topping(string type, int grams)
        {
            modifiers = new Dictionary<string, double>
            {
                {"meat", 1.2 },
                {"veggies", 0.8 },
                {"cheese", 1.1 },
                {"sauce", 0.9 }
            };

            this.Type = type;
            this.Grams = grams;
        }

        private string Type
        {
            get { return type; }
            set 
            {
                if (!modifiers.ContainsKey(value))
                {
                    var toppingNameWithUpperFirstLetter = value[0].ToString().ToUpper() + value.Substring(1);
                    throw new ArgumentException($"Cannot place {toppingNameWithUpperFirstLetter} on top of your pizza.");
                }

                type = value;
            }
        }

        private int Grams
        {
            get { return grams; }
            set
            {
                if (value < minValue || value > maxValue)
                {
                    var typeNameWithUpperFirstLetter = this.Type[0].ToString().ToUpper() + this.Type.Substring(1);
                    throw new ArgumentException($"{typeNameWithUpperFirstLetter} weight should be in the range [1..50].");
                }

                grams = value;
            }
        }

        public double GetToppingCalories()
        {
            var modifierCalories = modifiers.Where(x => x.Key == this.Type).Select(x => x.Value).First();
            return 2 * modifierCalories * this.Grams;
        }

    }
}
