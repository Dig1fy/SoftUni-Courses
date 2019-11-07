namespace SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var numberOfCars = int.Parse(Console.ReadLine());
            var listOfCars = new Car[numberOfCars];

            for (int i = 0; i < numberOfCars; i++)
            {                
                var commandInfo = Console.ReadLine().Split().ToArray();
                var currentModel = commandInfo[0];
                var currentFuelAmount = double.Parse(commandInfo[1]);
                var currentFuelConsumption = double.Parse(commandInfo[2]);

                var car = new Car();
                car.Model = currentModel;
                car.FuelAmount = currentFuelAmount;
                car.FuelConsumptionPerKilometer = currentFuelConsumption;
                
                listOfCars[i] = car;
            }

            var command = string.Empty;

            while ((command=Console.ReadLine())!="End")
            {
                var commandInfo = command.Split().ToArray();
                var driveModel = commandInfo[1];
                var driveAmountKilometers = double.Parse(commandInfo[2]);
                listOfCars.Where(x => x.Model == driveModel).ToList().ForEach(c => c.Move(driveAmountKilometers));

            }

            foreach (Car car in listOfCars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.TravelledDistance}");
            }
        }
    }
}
