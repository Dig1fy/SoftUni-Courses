namespace Vehicle_AnotherAproach
{
    public class Car : Vehicle
    {
        private const double additionalConsumption = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + additionalConsumption)
        {
        }
    }
}
