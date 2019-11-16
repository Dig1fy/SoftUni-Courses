namespace Vehicle_AnotherAproach
{
    public class Bus : Vehicle
    {
        private const double additionalAirconditionConsumption = 1.4;

        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity) 
            : base(fuelQuantity, fuelConsumption + additionalAirconditionConsumption, tankCapacity)
        {
        }

        public string DriveEmpty(double distance)
        {
            this.FuelConsumption -= additionalAirconditionConsumption;

            return base.Drive(distance);
        }
    }
}
