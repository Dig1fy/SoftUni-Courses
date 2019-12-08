namespace MXGP.Models.Riders
{
    using MXGP.Models.Motorcycles.Contracts;
    using MXGP.Models.Riders.Contracts;
    using System;

    public class Rider : IRider
    {
        private string name;
        
        public Rider(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
        }

        public string Name
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException($"Name {value} cannot be less than 5 symbols.");
                }

                this.name = value;
            }
        }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate { get; private set; }

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle is null)
            {
                throw new ArgumentNullException("Motorcycle cannot be null.");
            }

            this.Motorcycle = motorcycle;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}