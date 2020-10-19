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
            var problemName = this.problemsService.GetNameById(id);

            var viewModel = new CreateSubmissionViewModel()
            {
                Name = problemName,
                ProblemId = id
            };

            return this.View(viewModel);
        }

        [HttpPost]
        public HttpResponse Create(string x, string y)
        {
            return this.Redirect("/");
        }
    }
}
