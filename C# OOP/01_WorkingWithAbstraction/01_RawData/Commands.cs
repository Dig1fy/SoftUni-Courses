using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P01_RawData
{
    public class Commands
    {

        public void Run()
        {
            var lines = int.Parse(Console.ReadLine());
            var catalog = new CarCatalog();

            for (int i = 0; i < lines; i++)
            {
                var parameters = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                catalog.Add(parameters);
            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                var fragile = catalog.GetAllCars()
                    .Where(x => x.Cargo.Type == "fragile" && x.Tires.Any(y => y.Pressure < 1))
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, fragile));
            }
            else
            {
                var flamable = catalog.GetAllCars()
                    .Where(x => x.Cargo.Type == "flamable" && x.Engine.Power > 250)
                    .Select(x => x.Model)
                    .ToList();

                Console.WriteLine(string.Join(Environment.NewLine, flamable));
            }
        }

        
    }
}
