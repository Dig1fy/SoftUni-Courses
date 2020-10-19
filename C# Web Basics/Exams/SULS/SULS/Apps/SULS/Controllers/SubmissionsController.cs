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
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

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
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            if (string.IsNullOrWhiteSpace(code) || code.Length < 30 || code.Length > 800)
            {
                return this.Error("Code should be between 30 and 800 characters long");
            }

            var userId = this.GetUserId();
            this.submissionsService.Create(code, userId, problemId);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            this.submissionsService.Delete(id);
            return this.Redirect("/");
        }
    }
}
