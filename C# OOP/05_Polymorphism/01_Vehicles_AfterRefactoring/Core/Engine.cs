namespace Vehicles.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Vehicle_AnotherAproach;

    public class Engine
    {
        public void Run()
        {
            var listOfVehicles = new List<Vehicle>();

            for (int numberOfVehicle = 1; numberOfVehicle <= 2; numberOfVehicle++)
            {
                var tokens = Console.ReadLine()
               .Split();
                var fuelQuantity = double.Parse(tokens[1]);
                var consumption = double.Parse(tokens[2]);

                switch (numberOfVehicle)
                {
                    case 1:
                        Vehicle car = new Car(fuelQuantity, consumption);
                        listOfVehicles.Add(car);
                        break;
                    case 2:
                        Vehicle truck = new Truck(fuelQuantity, consumption);
                        listOfVehicles.Add(truck);
                        break;
                }
            }

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int num = 0; num < numberOfCommands; num++)
            {
                var inputArgs = Console.ReadLine().Split();
                var action = inputArgs[0];
                var typeOfVehicle = inputArgs[1];
                var parameter = double.Parse(inputArgs[2]);

                foreach (var vehicle in listOfVehicles.Where(x => x.GetType().Name.Equals(typeOfVehicle)))
                {
                    ExecuteCommand(vehicle, parameter, action);
                }
            }

            foreach (var vehicle in listOfVehicles)
            {
                Console.WriteLine(vehicle);
            }

        }

        private static void ExecuteCommand(Vehicle vehicle, double parameter, string action)
        {
            switch (action)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(parameter));
                    break;
                case "Refuel":
                    vehicle.Refuel(parameter);
                    break;
            }
        }
    }
}
