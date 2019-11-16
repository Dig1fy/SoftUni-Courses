using CarsSalesman;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarsSalesman
{
    public class CarSalesman
    {
        private List<Car> cars;
        private List<Engine> engines;
        private EngineFactory engineFactory;
        private CarFactory carFactory;

        public CarSalesman(EngineFactory engineFactory, CarFactory carFactory)
        {
            this.cars = new List<Car>();
            this.engines = new List<Engine>();
            this.carFactory = carFactory;
            this.engineFactory = engineFactory;
        }

        public void AddEngine(string[] parameters)
        {
            var engine = engineFactory.Create(parameters);
            engines.Add(engine);
        }

        public void AddCar(string[] parameters)
        {
            var car = carFactory.Create(parameters, this.engines);
            cars.Add(car);
        }

        public List<Car> GetCars()
        {
            return this.cars;
        }
    }

}
