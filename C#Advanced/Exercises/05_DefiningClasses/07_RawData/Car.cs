namespace RawData
{
    public class Car
    {
        private string model;
        private Engine engine;
        private Cargo cargo;
        private Tire[] tires;

        public Car(string model, Engine engine, Tire[] tires, Cargo cargo)
        {
            Model = model;
            Engine = engine;
            Tires = tires;
            Cargo = cargo;
        }

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine Engine
        {
            get { return engine; }
            set { engine = value; }
        }
        public Tire[] Tires
        {
            get { return tires; }
            set { tires = value; }
        }
        public Cargo Cargo
        {
            get { return cargo; }
            set { cargo = value; }
        }
    }
}
