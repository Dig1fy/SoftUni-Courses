using Git.ViewModels.Commits;
using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface ICommitsService
    {
        IEnumerable<CommitsViewModel> GetAll();

        string GetNameById(string id);

        string CreateCommit(string description, string id, string userId, string repoId);

        void Delete(string id, string userId);
    }
}
