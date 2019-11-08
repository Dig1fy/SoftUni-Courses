namespace AnimalFarm.Models
{
    using System;

    public class Chicken
    {
        private const int MinAge = 0;
        private const int MaxAge = 15;
        private string name;
        private int age;

        internal Chicken(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        private string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty.");
                }
                this.name = value;
            }
        }

        private int Age
        {
            get
            {
                return this.age;
            }

            set
            {
                if (value < MinAge || value > MaxAge)
                {
                    throw new ArgumentException("Age should be between 0 and 15.");
                }
                this.age = value;
            }
        }

        public double ProductPerDay
        {
            get
            {
                return this.CalculateProductPerDay();
            }
        }

        private double CalculateProductPerDay()
        {
            if (this.Age <= 3)
            {
                return 1.5;
            }
            else if (this.Age > 3 && this.Age <= 7)
            {
                return 2;
            }
            else if (this.Age > 7 && this.Age <= 11)
            {
                return 1;
            }
            else
            {
                return 0.75;
            }
        }

        public override string ToString()
        {
            return $"Chicken {this.Name} (age {this.Age}) can produce {this.ProductPerDay} eggs per day.";
        }
    }
}
