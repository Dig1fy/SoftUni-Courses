namespace RawData
{
    public class Tire
    {
        private int tireAge;
        private double tirePressure;

        public Tire(int tireAge, double tirePressure)
        {
            TireAge = tireAge;
            TirePressure = tirePressure;
        }

        public int TireAge
        {
            get { return tireAge; }
            set { tireAge = value; }
        }

        public double TirePressure
        {
            get { return tirePressure; }
            set { tirePressure = value; }
        }

    }
}
