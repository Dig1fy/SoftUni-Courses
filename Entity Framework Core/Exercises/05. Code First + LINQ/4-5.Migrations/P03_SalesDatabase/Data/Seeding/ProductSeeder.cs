using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Data.Seeding.Contracts;
using P03_SalesDatabase.IOManagement.Contracts;
using System;
using System.Collections.Generic;

namespace P03_SalesDatabase.Data.Seeding
{
    public class ProductSeeder : ISeeder
    {
        private readonly SalesContext dbContext;
        private readonly Random random;
        private readonly IWriter writer;
        ICollection<Product> listOfProducts;

        public ProductSeeder(SalesContext context, Random random, IWriter writer)
        {
            this.dbContext = context;
            this.random = random;
            this.listOfProducts = new List<Product>();
            this.writer = writer;
        }
        public void Seed()
        {
            var names = new string[]{
            "CPU",
            "MotherBoard",
            "RAM",
            "SSD",
            "HDD",
            "GPU",
            "Air Cooler",
            "Water Cooler"
            };

            for (int i = 0; i < 50; i++)
            {
                var nameIndex = this.random.Next(names.Length);
                var currentName = names[nameIndex];
                var quantity = this.random.Next(1000);
                var price = this.random.Next(5000) * 1.34m;

                var product = new Product
                {
                    Name = currentName,
                    Price = price,
                    Quantity = quantity
                };

                listOfProducts.Add(product);

                this.writer.WriteLine($"Product (Name):{currentName}, (Quantity): {quantity}, (Price):{price} was added to the database.");
            }

            this.dbContext
                .Products
                .AddRange(listOfProducts);

            this.dbContext
                .SaveChanges();
        }
    }
}
