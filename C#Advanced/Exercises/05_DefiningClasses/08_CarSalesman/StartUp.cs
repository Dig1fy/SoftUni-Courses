namespace CarSalesman
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    class StartUp
    {
        static void Main(string[] args)
        {
            var numberOfEngines = int.Parse(Console.ReadLine());
            var listOfEngines = new List<Engine>();
            var listOfCars = new List<Car>();

            for (int i = 0; i < numberOfEngines; i++)
            {
                var engineInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

                var model = engineInfo[0];
                var power = int.Parse(engineInfo[1]);
                var currentEngine = new Engine(model, power);

                if (engineInfo.Count > 2 && char.IsDigit(engineInfo[2][0]))
                {
                    var displacement = engineInfo[2];
                    currentEngine.Displacement = displacement;
                }
                else if (engineInfo.Count > 2 && char.IsLetter(engineInfo[2][0]))
                {
                    var efficiency = engineInfo[2];
                    currentEngine.Efficiency = efficiency;
                }

                if (engineInfo.Count > 3)
                {
                    var efficiency = engineInfo[3];
                    currentEngine.Efficiency = efficiency;
                }

                listOfEngines.Add(currentEngine);
            }

            var numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                var carsInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();
                var model = carsInfo[0];
                var engine = carsInfo[1];

                var currentCar = new Car();

                foreach (var eng in listOfEngines)
                {
                    if (eng.Model == engine)
                    {
                        currentCar.Engine = eng;
                        break;
                    }
                }

                currentCar.Model = model;

                if (carsInfo.Count > 2 && char.IsDigit(carsInfo[2][0]))
                {
                    var carWeight = carsInfo[2];
                    currentCar.Weight = carWeight;
                }
                else if (carsInfo.Count > 2 && char.IsLetter(carsInfo[2][0]))
                {
                    var carsColor = carsInfo[2];
                    currentCar.Color = carsColor;
                }
                if (carsInfo.Count > 3)
                {
                    var carsColor = carsInfo[3];
                    currentCar.Color = carsColor;
                }

                listOfCars.Add(currentCar);
            }

            var stringBuilder = new StringBuilder();

            foreach (var car in listOfCars)
            {
               stringBuilder.AppendLine(AddPrintInfo(car));
            }

            Console.WriteLine(stringBuilder);
            
        }
        private static string AddPrintInfo(Car car)
        {
            var tempBuilder = new StringBuilder();
            tempBuilder.AppendLine($"{car.Model}:");
            tempBuilder.AppendLine($"  {car.Engine.Model}:");
            tempBuilder.AppendLine($"    Power: {car.Engine.Power}");
            tempBuilder.AppendLine($"    Displacement: {car.Engine.Displacement}");
            tempBuilder.AppendLine($"    Efficiency: {car.Engine.Efficiency}");
            tempBuilder.AppendLine($"  Weight: {car.Weight}");
            tempBuilder.AppendLine($"  Color: {car.Color}");
            return tempBuilder.ToString().TrimEnd();
        }
    }
}
