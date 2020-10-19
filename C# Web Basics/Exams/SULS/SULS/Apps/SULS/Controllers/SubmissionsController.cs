using SULS.Services;
using SULS.ViewModels.Submissions;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class SubmissionsController: Controller
    {
        private readonly IProblemsService problemsService;
        private readonly ISubmissionsService submissionsService;

        public SubmissionsController(IProblemsService problemsService, ISubmissionsService submissionsService)
        {
            this.problemsService = problemsService;
            this.submissionsService = submissionsService;
        }

        //Load submissions form for each problem
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
        public HttpResponse Create(string code, string problemId)
        {
            var userId = this.GetUserId();
            this.submissionsService.Create(code, userId, problemId);

            return this.Redirect("/");
        }
    }
}
