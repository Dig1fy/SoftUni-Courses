namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;

    public class Planet : IPlanet
    {
        private string name;
        private List<string> planetItems;
        public Planet(string name)
        {
            this.Name = name;
            this.planetItems = new List<string>();
        }
        
        public ICollection<string> Items => this.planetItems;

        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Invalid name!");
                }

                this.name = value;
            }
        }
    }
}
