namespace SULS.Services
{
    public interface ISubmissionsService
    {
        public void Create(string code, string userId, string problemId);

        public void Delete(string id);
    }
}
