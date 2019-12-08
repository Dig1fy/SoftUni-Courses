namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const double CUBIC_CENTIMETERS = 125;
        private const int MIN_HORSEPOWER = 50;
        private const int MAX_HORSEPOWER = 69;

        public SpeedMotorcycle(string model, int horsePower) 
            : base(model, horsePower, CUBIC_CENTIMETERS, MIN_HORSEPOWER, MAX_HORSEPOWER)
        {            
        }     
    }
}