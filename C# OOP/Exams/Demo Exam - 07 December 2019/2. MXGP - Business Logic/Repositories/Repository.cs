namespace MXGP.Repositories
{
    using MXGP.Repositories.Contracts;
    using System.Collections.Generic;

    public abstract class Repository<T> : IRepository<T>
    {
        protected readonly List<T> allModels;

        protected Repository()
        {
            this.allModels = new List<T>();
        }

        public void Add(T model)
        {
            if (!allModels.Contains(model))
            {
                this.allModels.Add(model);
            }
        }

        public IReadOnlyCollection<T> GetAll()
            => this.allModels.AsReadOnly();

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
           return this.allModels.Remove(model);
        }
    }
}