using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> Cars { get; set; }
        private int capacity { get; set; }
        public int Count => this.Cars.Count();

        public Parking(int capacity)
        {
            this.Cars = new List<Car>();
            this.capacity = capacity;
        }

        public string AddCar(Car car)
        {
            if (this.Cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            if (this.Cars.Count == this.capacity)
            {
                return "Parking is full!";
            }
            this.Cars.Add(car);
            return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
        }

        public string RemoveCar(string registrationNumber)
        {
            if (Cars.Any(car => car.RegistrationNumber == registrationNumber))
            {
                var carToRemove = this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
                this.Cars.Remove(carToRemove);

                return $"Successfully removed {registrationNumber}";
            }
            else
            {
                return $"Car with that registration number, doesn't exist!";
            }
        }
        public Car GetCar(string registrationNumber)
        {
            return this.Cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var number in registrationNumbers)
            {
                Cars.RemoveAll(c => c.RegistrationNumber == number);
            }
        }
    }
}