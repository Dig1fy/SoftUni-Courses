namespace MXGP.Repositories
{
    using MXGP.Models.Motorcycles.Contracts;

    public class MotorcycleRepository : Repository<IMotorcycle>
    {
        public override IMotorcycle GetByName(string name)
        {
            var currentMotorcycle = this.allModels.Find(x => x.Model == name);
            return currentMotorcycle;
        }
    }
}