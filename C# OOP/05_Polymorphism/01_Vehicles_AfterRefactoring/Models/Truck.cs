namespace Vehicle_AnotherAproach
{
    public class Truck : Vehicle
    {
        private const double additionalTruckConsumption = 1.6;
        private const double fuelLeaks = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
            this.FuelConsumption = fuelConsumption + additionalTruckConsumption;
        }

        public double FuelConsuption { get; private set; }
        public override void Refuel(double liters)
        {
            FuelQuantity +=  liters*fuelLeaks;
        }
    }
}
