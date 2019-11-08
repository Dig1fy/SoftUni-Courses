namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        public void Run()
        {
            var people = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var products = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            var allPeople = new List<Person>();
            var allProducts = new List<Product>();

            try
            {
                foreach (var currentInput in people)
                {
                    var args = currentInput.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var personName = args[0];
                    var personsMoney = decimal.Parse(args[1]);
                    var person = new Person(personName, personsMoney);
                    allPeople.Add(person);
                }

                foreach (var currentInput in products)
                {
                    var args = currentInput.Split(new char[] { '=' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                    var productName = args[0];
                    var productPrice = decimal.Parse(args[1]);
                    var product = new Product(productName, productPrice);
                    allProducts.Add(product);
                }

                var command = string.Empty;

                while ((command = Console.ReadLine()) != "END")
                {
                    var commandArgs = command.Split();
                    var currentPerson = commandArgs[0];
                    var currentProduct = commandArgs[1];
                    var product = allProducts.FirstOrDefault(x => x.Name == currentProduct);

                    try
                    {
                        allPeople.FirstOrDefault(x => x.Name.Equals(currentPerson)).AddProduct(product);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            foreach (var person in allPeople)
            {
                Console.WriteLine(person.ToString());
            }
        }
    }
}
