namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        private decimal money;
        private string name;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                name = value;
            }
        }

        private decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                money = value;
            }
        }

        public override string ToString()
        {
            if (products.Count == 0)
            {
                return $"{this.Name} - Nothing bought".TrimEnd();
            }

            var productsNames = this.products.Select(x => x.Name);
            return $"{this.Name} - {string.Join(", ", productsNames)}";

        }
        public void AddProduct(Product product)
        {
            if (this.money < product.Cost)
            {
                throw new ArgumentException($"{this.name} can't afford {product.Name}");
            }

            Console.WriteLine($"{this.name} bought {product.Name}");
            this.money -= product.Cost;
            this.products.Add(product);
        }
    }
}
