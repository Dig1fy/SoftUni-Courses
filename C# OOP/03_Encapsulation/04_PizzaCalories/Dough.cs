namespace PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dough
    {
        private string bakingTechnique;
        private string flourType;
        private int grams;
        private Dictionary<string, double> allFlourTypes;
        private Dictionary<string, double> allBakingTechniques;
        private const int minimumDoughGrams = 1;
        private const int maximumDoughGrams = 200;

        public Dough(string flourType, string backingTechnique, int grams)
        {

            allFlourTypes = new Dictionary<string, double>
            {
                { "white",  1.5 },
                { "wholegrain" , 1 }
            };

            allBakingTechniques = new Dictionary<string, double>
            {
                { "crispy",  0.9 },
                { "chewy" , 1.1 },
                { "homemade" , 1 }
            };

            this.FlourType = flourType;
            this.BackingTechnique = backingTechnique;
            this.Grams = grams;
        }

        private string FlourType
        {
            get { return flourType; }
            set
            {
                if (!allFlourTypes.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.flourType = value;
            }
        }

        private string BackingTechnique
        {
            get { return bakingTechnique; }
            set
            {
                if (!allBakingTechniques.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }

                this.bakingTechnique = value;
            }
        }

        private int Grams
        {
            get { return grams; }
            set
            {
                if (value < minimumDoughGrams || value > maximumDoughGrams)
                {
                    throw new ArgumentException("Dough weight should be in the range[1..200].");
                }

                grams = value;
            }
        }

        public double GetDoughCalories()
        {
            var flour = allFlourTypes.Where(x => x.Key == this.FlourType).Select(x => x.Value).First();
            var technique = allBakingTechniques.Where(x => x.Key == bakingTechnique).Select(x => x.Value).First();

            return 2 * this.Grams * flour * technique;
        }
    }
}
