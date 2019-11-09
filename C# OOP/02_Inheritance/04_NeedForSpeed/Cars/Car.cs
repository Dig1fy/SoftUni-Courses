namespace NeedForSpeed.Cars
{
    public class Car : Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 3.0;
        public Car(int horsePower, double fuel)
            : base (horsePower, fuel)
        {

        }

        public override double fuelConsumption => DEFAULT_FUEL_CONSUMPTION;
    }
}
