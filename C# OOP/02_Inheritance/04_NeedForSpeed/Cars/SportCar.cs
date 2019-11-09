namespace NeedForSpeed.Cars
{
    public class SportCar : Car
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 10D;

        public SportCar(int horsePower, double fuel)
            : base (horsePower, fuel)
        {

        }

        public override double fuelConsumption => DEFAULT_FUEL_CONSUMPTION;

    }
}
