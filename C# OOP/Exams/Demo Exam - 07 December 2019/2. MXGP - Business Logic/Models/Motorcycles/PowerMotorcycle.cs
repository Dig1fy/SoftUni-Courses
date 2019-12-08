namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 450;
        private const int MIN_HORSEPOWER = 70;
        private const int MAX_HORSEPOWER = 100;

        public PowerMotorcycle(string model, int horsePower)
            : base(model, horsePower, CUBIC_CENTIMETERS, MIN_HORSEPOWER, MAX_HORSEPOWER)
        {            
        }
    }
}