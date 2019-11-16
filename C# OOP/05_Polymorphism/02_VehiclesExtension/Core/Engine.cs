namespace Vehicle_AfterRefactoring.Core
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

            for (int i = 0; i < 3; i++)
            {
                var args = Console.ReadLine()
                .Split();
                var fuelQuantity = double.Parse(args[1]);
                var consumption = double.Parse(args[2]);
                var tankCapacity = double.Parse(args[3]);

                switch (i)
                {
                    case 0:
                        Vehicle car = new Car(fuelQuantity, consumption, tankCapacity);
                        listOfVehicles.Add(car);
                        break;
                    case 1:
                        Vehicle truck = new Truck(fuelQuantity, consumption, tankCapacity);
                        listOfVehicles.Add(truck);
                        break;
                    case 2:
                        Vehicle bus = new Bus(fuelQuantity, consumption, tankCapacity);
                        listOfVehicles.Add(bus);
                        break;
                }
            }

            var numberOfCommands = int.Parse(Console.ReadLine());

            for (int num = 0; num < numberOfCommands; num++)
            {
                var input = Console.ReadLine().Split();
                var action = input[0];
                var typeOfVehicle = input[1];
                var parameter = double.Parse(input[2]);

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

        private void ExecuteCommand(Vehicle vehicle, double parameter, string action)
        {
            switch (action)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(parameter));
                    break;
                case "Refuel":
                    try
                    {
                        vehicle.Refuel(parameter);
                    }
                    catch (Exception ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    break;
                case "DriveEmpty":
                    Bus bus = vehicle as Bus;
                    Console.WriteLine(bus.DriveEmpty(parameter));
                    break;
            }
        }
    }
}
