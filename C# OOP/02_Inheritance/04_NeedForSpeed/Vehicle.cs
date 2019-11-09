namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            this.HorsePower = horsePower;
            this.Fuel = fuel;
        }

        public virtual double fuelConsumption => DEFAULT_FUEL_CONSUMPTION;
        public double Fuel { get; set; }
        public int HorsePower { get; set; }

        public virtual void Drive(double kilometers)
        {
            if (this.Fuel - this.fuelConsumption * kilometers >= 0)
            {
                this.Fuel -= this.fuelConsumption * kilometers;
            }
        }
    }
}
