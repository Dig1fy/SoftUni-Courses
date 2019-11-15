namespace Vehicle_Refactored
{
    using System;

    public abstract class Vehicle : IVehicle
    {
        protected Vehicle(double fuelQuantity, double fuelConsumption)
        {
            this.fuelQuantity = fuelQuantity;
            this.fuelConsumption = fuelConsumption;
        }

        public double fuelQuantity { get; set; }
        public double fuelConsumption { get; set; }

        public string Drive(double kilometers)
        {
            var requiredFuel = this.fuelConsumption * kilometers;

            if (this.fuelQuantity < requiredFuel)
            {
                throw new ArgumentException($"{this.GetType().Name} needs refueling");
            }

            this.fuelQuantity -= requiredFuel;

            return ($"{this.GetType().Name} travelled {kilometers} km");
        }

        public virtual void Refuel(double liters)
        {
            this.fuelQuantity += liters;
        }

        public override string ToString()
        {
            return ($"{this.GetType().Name}: {fuelQuantity:F2}");
        }
    }
}
