namespace Vehicle_Refactored
{
    public class Car : Vehicle
    {
        private const double additionalConsupmtion = 0.9;
        public Car(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption + additionalConsupmtion)
        {
        }
    }
}
