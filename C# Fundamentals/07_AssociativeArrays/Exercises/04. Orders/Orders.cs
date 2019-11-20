using System;
using System.Collections.Generic;
using System.Linq;

namespace Orders
{
    class Program
    {
        static void Main()
        {
            var productsPrice = new Dictionary<string, double>();
            var productsQy = new Dictionary<string, int>();

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "buy")
            {
                string[] current = command
                    .Split()
                    .ToArray();
                string product = current[0];
                double price = double.Parse(current[1]);
                int quantity = int.Parse(current[2]);

                productsPrice[product] = price;

                if (!productsQy.ContainsKey(product))
                {
                    productsQy[product] = 0;
                }

                productsQy[product] += quantity;
            }

            foreach (var product in productsQy)
            {
                string currentProduct = product.Key;
                double price = productsPrice[currentProduct] * product.Value;

                Console.WriteLine($"{currentProduct} -> {price:f2}");
            }
        }
    }
}