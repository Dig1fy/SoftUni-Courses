using SULS.ViewModels.Home;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemsService
    {
        public void Create(string name, int points);

        IEnumerable<HomePageViewModel> GetAll();

        string GetNameById(string id);
    }
}
