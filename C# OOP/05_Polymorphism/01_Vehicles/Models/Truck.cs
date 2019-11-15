namespace Vehicle_Refactored
{
    public class Truck : Vehicle
    {
        private const double fuelLeaks = 0.95;
        private const double additionalFuelConsumption = 1.6;
        public Truck(double fuelQuantity, double fuelConsumption)
            : base(fuelQuantity, fuelConsumption + additionalFuelConsumption)
        {
        }

        public override void Refuel(double liters)
        {
            this.fuelQuantity += liters * fuelLeaks;
        }
    }
}
