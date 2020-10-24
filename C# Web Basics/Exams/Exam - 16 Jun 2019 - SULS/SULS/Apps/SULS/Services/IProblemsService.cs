using SULS.ViewModels.Home;
using SULS.ViewModels.Problems;
using SULS.ViewModels.Submissions;
using System.Collections;
using System.Collections.Generic;

namespace SULS.Services
{
    public interface IProblemsService
    {
        IEnumerable<HomePageViewModel> GetAll();

        void Create(CreateProblemInputModel inputModel);

        string GetNameById(string id);
    }
}
