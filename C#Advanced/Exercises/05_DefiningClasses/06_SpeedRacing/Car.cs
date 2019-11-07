namespace SpeedRacing
{
    using System;

    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumptionPerKilometer;
        private double travelledDistance;

        public Car()
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumptionPerKilometer = fuelConsumptionPerKilometer;
            TravelledDistance = 0;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public double FuelAmount
        {
            get { return fuelAmount; }
            set { fuelAmount = value; }
        }

        public double FuelConsumptionPerKilometer
        {
            get { return fuelConsumptionPerKilometer; }
            set { fuelConsumptionPerKilometer = value; }
        }

        public double TravelledDistance
        {
            get { return travelledDistance; }
            set { travelledDistance = value; }
        }

        public void Move(double distance)
        {
            if (this.fuelAmount < distance * this.fuelConsumptionPerKilometer)
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
            else
            {
                this.FuelAmount -= distance * this.FuelConsumptionPerKilometer;
                this.TravelledDistance += distance;
            }
        }
    }
}
