namespace Vehicle_AnotherAproach
{
    public class Truck : Vehicle
    {
        private const double additionalTruckConsumption = 1.6;
        private const double fuelLeaks = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)
        {
            this.FuelConsumption = fuelConsumption + additionalTruckConsumption;
        }

        public double FuelConsuption { get; private set; }
        public override void Refuel(double liters)
        {
            if (liters + this.FuelQuantity <= TankCapacity)
            {
                liters *= fuelLeaks;
            }

            base.Refuel(liters);
        }
    }
}