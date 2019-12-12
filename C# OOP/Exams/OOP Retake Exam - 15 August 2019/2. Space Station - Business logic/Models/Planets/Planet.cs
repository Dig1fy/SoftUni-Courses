namespace SpaceStation.Models.Planets
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Planet : IPlanet
    {
        private string name;
        private List<string> planetItems = new List<string>();
        public Planet(string name, string[] planetItems)
        {
            this.Name = name;
            this.planetItems = planetItems.ToList();
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
