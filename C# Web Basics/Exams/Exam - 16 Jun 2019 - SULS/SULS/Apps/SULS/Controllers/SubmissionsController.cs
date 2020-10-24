using SULS.Services;
using SULS.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class SubmissionsController: Controller
    {
        private readonly IProblemsService problemsService;

        public SubmissionsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }
        public HttpResponse Create(string id)
        {
            var viewModel = new CreateSubmissionViewModel
            {
                Name = this.problemsService.GetNameById(id),
                ProblemId = id
            };
                
            return this.View(viewModel);
        }
    }
}
