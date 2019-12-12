namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Planets;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class PlanetRepository : IRepository<IPlanet>
    {
        private List<IPlanet> listOfPlanets;

        public PlanetRepository()
        {
            this.listOfPlanets = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models
            => this.listOfPlanets.AsReadOnly();

        public void Add(IPlanet model)
        {
            this.listOfPlanets.Add(model);
        }

        public IPlanet FindByName(string name)
        => this.listOfPlanets.FirstOrDefault(x => x.Name == name);

        public bool Remove(IPlanet model)
        => this.listOfPlanets.Remove(model);
    }
}
