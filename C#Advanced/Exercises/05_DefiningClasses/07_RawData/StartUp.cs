namespace RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class StartUp
    {
        static void Main(string[] args)
        {

            var listOfCars = new List<Car>();
            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var inputInfo = Console.ReadLine().Split().ToArray();
                var model = inputInfo[0];

                var engineSpeed = int.Parse(inputInfo[1]);
                var enginePower = int.Parse(inputInfo[2]);


                var cargoWeight = int.Parse(inputInfo[3]);
                var cargoType = inputInfo[4];

                var tires = new Tire[4];
                var counter = 0;

                for (int j = 5; j < inputInfo.Length; j += 2)
                {
                    var tirePressure = double.Parse(inputInfo[j]);
                    var tireAge = int.Parse(inputInfo[j + 1]);
                    var tire = new Tire(tireAge, tirePressure);

                    tires[counter] = tire;
                    counter++;
                }

                var engine = new Engine(engineSpeed, enginePower);
                var cargo = new Cargo(cargoWeight, cargoType);
                var car = new Car(model, engine, tires, cargo);
                listOfCars.Add(car);
            }

            var command = Console.ReadLine();

            if (command == "fragile")
            {
                listOfCars
                    .Where(x => x.Cargo.CargoType == command && x.Tires.Any(c => c.TirePressure < 1))
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));

            }
            else if (command == "flamable")
            {
                listOfCars
                    .Where(x => x.Cargo.CargoType == command && x.Engine.EnginePower > 250)
                    .ToList()
                    .ForEach(x => Console.WriteLine(x.Model));
            }
        }
    }
}
