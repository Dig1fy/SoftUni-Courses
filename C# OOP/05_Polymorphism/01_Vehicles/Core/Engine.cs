namespace Vehicle_Refactored.Core
{
    using System;
    using System.Linq;
    using IO;
    public class Engine
    {
        public void Run()
        {
            var carInput = Reader.ReadLine()
                .Split()
                .ToArray();
            var initialFuel = double.Parse(carInput[1]);
            var fuelConsuption = double.Parse(carInput[2]);
            Vehicle car = new Car(initialFuel, fuelConsuption);

            var truckInput = Reader.ReadLine()
                .Split()
                .ToArray();
            initialFuel = double.Parse(truckInput[1]);
            fuelConsuption = double.Parse(truckInput[2]);
            var truck = new Truck(initialFuel, fuelConsuption);

            var numberOfCommands = int.Parse(Reader.ReadLine());

            for (int num = 0; num < numberOfCommands; num++)
            {
                try
                {
                    var input = Reader.ReadLine()
                        .Split();

                    var vehicleType = input[1];
                    var action = input[0];
                    var parameter = double.Parse(input[2]);

                    switch (vehicleType)
                    {
                        case nameof(Car):
                            ExecuteCommand(car, action, parameter);
                            break;
                        case nameof(Truck):
                            ExecuteCommand(truck, action, parameter);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Writer.WriteLine(ex.Message);
                }
            }

            Writer.WriteLine(car.ToString());
            Writer.WriteLine(truck.ToString());
        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
                    break;
                case "Refuel":
                    vehicle.Refuel(value);
                    break;
            }
        }
    }
}
