namespace SpaceStation.Repositories
{
    using SpaceStation.Models.Astronauts.Contracts;
    using SpaceStation.Repositories.Contracts;
    using System.Collections.Generic;
    using System.Linq;

    public class AstronautRepository : IRepository<IAstronaut>
    {
        private readonly List<IAstronaut> listOfAstronauts;

        public AstronautRepository()
        {
            this.listOfAstronauts = new List<IAstronaut>();
        }
            
        public IReadOnlyCollection<IAstronaut> Models 
            => this.listOfAstronauts.AsReadOnly();

        public void Add(IAstronaut model)
        {
            this.listOfAstronauts.Add(model);
        }

        public IAstronaut FindByName(string name)
         => this.listOfAstronauts.FirstOrDefault(x => x.Name == name);

        public bool Remove(IAstronaut model)
         => this.listOfAstronauts.Remove(model);
    }
}