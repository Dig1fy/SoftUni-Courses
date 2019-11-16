using System;
using System.Collections.Generic;
using System.Text;

namespace CarsSalesman
{
   public class StartUp
    {
        static void Main(string[] args)
        {
            var carFactory = new CarFactory();
            var engineFactory = new EngineFactory();
            var carSalesman = new CarSalesman(engineFactory, carFactory);
            int engineCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < engineCount; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                carSalesman.AddEngine(parameters);
            }
            var carCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < carCount; i++)
            {
                var parameters = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                carSalesman.AddCar(parameters);
            }

            foreach (var car in carSalesman.GetCars())
            {
                Console.WriteLine(car);
            }
        }
    }
}
