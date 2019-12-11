namespace ViceCity.Repositories
{
    using System.Collections.Generic;
    using ViceCity.Models.Guns.Contracts;
    using ViceCity.Repositories.Contracts;

    public class GunRepository : IRepository<IGun>
    {
        private readonly List<IGun> listOfGuns;

        public GunRepository()
        {
            this.listOfGuns = new List<IGun>();
        }
        public IReadOnlyCollection<IGun> Models
            => listOfGuns.AsReadOnly();

        public void Add(IGun model)
        {
            if (!this.listOfGuns.Contains(model))
            {
                this.listOfGuns.Add(model);
            }
        }

        public IGun Find(string name)
            => this.listOfGuns.Find(x=>x.Name == name);

        public bool Remove(IGun model)
             => this.listOfGuns.Remove(model);

    }
}