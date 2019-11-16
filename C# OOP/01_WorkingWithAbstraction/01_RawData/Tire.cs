using System;
using System.Collections.Generic;
using System.Text;

namespace RawData
{
    public class Tire
    {
        private int age;

        public Tire(int age, double pressure)
        {
            this.age = age;
            this.Pressure = pressure;
        }

        public double Pressure { get; set; }
    }
}
