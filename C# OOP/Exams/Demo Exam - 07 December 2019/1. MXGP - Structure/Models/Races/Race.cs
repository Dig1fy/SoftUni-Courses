namespace MXGP.Models.Races
{
    using MXGP.Models.Races.Contracts;
    using MXGP.Models.Riders.Contracts;
    using System;
    using System.Collections.Generic;

    public class Race : IRace
    {
        private string name;
        private int laps;
        private List<IRider> riders;

        public Race(string name, int laps)
        {
            this.Name = name;
            this.Laps = laps;

            this.riders = new List<IRider>();
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

        public int Laps
        {
            get => this.laps;

            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Laps cannot be less than 1.");
                }

                this.laps = value;
            }
        }

        public IReadOnlyCollection<IRider> Riders => this.riders;

        public void AddRider(IRider rider)
        {
            if (rider is null)
            {
                throw new ArgumentNullException("Rider cannot be null.");
            }

            else if (!rider.CanParticipate)
            {
                throw new ArgumentNullException($"Rider {rider.Name} could not participate in race.");
            }

            else if (this.riders.Contains(rider))
            {
                throw new ArgumentNullException($"Rider {rider.Name} is already added in {this.Name} race.");
            }

            this.riders.Add(rider);
        }
    }
}