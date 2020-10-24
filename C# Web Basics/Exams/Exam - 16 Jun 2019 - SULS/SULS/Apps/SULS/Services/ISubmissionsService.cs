using SULS.ViewModels.Submissions;

namespace SULS.Services
{
    public interface ISubmissionsService
    {
        void Create(string problemId, string userId, string code);

        void Delete(string id);
    }
}
