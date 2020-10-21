using SULS.ViewModels.Home;
using SULS.ViewModels.Problems;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemsService
    {
        public void Create(string name, int points);

        IEnumerable<HomePageViewModel> GetAll();

        string GetNameById(string id);

        public ProblemViewModel GetModеlById(string id);
    }
}
