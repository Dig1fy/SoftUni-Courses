namespace P01_RawData
{
    using RawData;
    using System;
    using System.Collections.Generic;
    using System.Text;
    public class CarCatalog
    {
        private List<Car> cars;

        public CarCatalog()
        {
            cars = new List<Car>();
        }
        public void Add(string[] parameters)
        {
            var model = parameters[0];
            var engineSpeed = int.Parse(parameters[1]);
            var enginePower = int.Parse(parameters[2]);
            var engine = new Engine(engineSpeed, enginePower);

            var cargoWeight = int.Parse(parameters[3]);
            var cargoType = parameters[4];
            var cargo = new Cargo(cargoWeight, cargoType);

            var tires = new List<Tire>();

            for (int tireCount = 5; tireCount < parameters.Length; tireCount += 2)
            {
                var tirePressure = double.Parse(parameters[tireCount]);
                var tireAge = int.Parse(parameters[tireCount + 1]);
                var tire = new Tire(tireAge, tirePressure);
                tires.Add(tire);
            }

            var car = new Car(model, engine, cargo, tires);
            cars.Add(car);
            
        }

        public List<Car> GetAllCars() => this.cars;

    }
}
