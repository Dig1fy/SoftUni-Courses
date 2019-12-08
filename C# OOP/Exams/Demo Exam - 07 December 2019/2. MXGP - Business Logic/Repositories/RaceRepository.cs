namespace MXGP.Repositories
{
    using MXGP.Models.Races.Contracts;

    public class RaceRepository : Repository<IRace>
    {
        public override IRace GetByName(string name)
        {
            var wantedMotorcycle = this.allModels.Find(x => x.Name == name);
            return wantedMotorcycle;
        }
    }
}