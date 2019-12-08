namespace MXGP.Repositories
{
    using MXGP.Models.Riders.Contracts;

    public class RiderRepository : Repository<IRider>
    {
        public override IRider GetByName(string name)
        {
            var currentRider = this.allModels.Find(x => x.Name == name);
            return currentRider;
        }
    }
}