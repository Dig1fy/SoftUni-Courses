using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
   public class Car
    {       
        public Car(string model, Engine engine, Cargo cargo, List<Tire> tires)
        {
            this.Model = model;
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tires = tires;
        }

        public Engine Engine { get; private set; }
        public Cargo Cargo { get; private set; }
        public List<Tire> Tires{ get; private set; }
        public string Model { get; private set; }

    }
}
