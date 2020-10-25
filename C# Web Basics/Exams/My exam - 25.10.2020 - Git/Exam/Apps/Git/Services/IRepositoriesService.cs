using Git.ViewModels.Repositories;
using System.Collections.Generic;

namespace Git.Services
{
    public interface IRepositoriesService
    {
        IEnumerable<RepositoryViewModel> GetAll();

        string CreateRepo(string name, string repositoryType, string userId);
    }
}
