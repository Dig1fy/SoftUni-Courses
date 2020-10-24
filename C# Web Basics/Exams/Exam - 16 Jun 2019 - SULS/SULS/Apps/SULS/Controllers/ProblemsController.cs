using SULS.Services;
using SULS.ViewModels.Problems;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SULS.Controllers
{
    public class ProblemsController: Controller
    {
        private readonly IProblemsService problemsService;

        public ProblemsController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(CreateProblemInputModel inputModel)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Name) || inputModel.Name.Length < 5 || inputModel.Name.Length >20 )
            {
                return this.Error("Problem's name should be between 5 and 20 characters long.");
            }

            if (inputModel.Points < 50 || inputModel.Points > 300)
            {
                return this.Error("Points should be in range 50 - 300");
            }

            this.problemsService.Create(inputModel);
            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.problemsService.getProblemById(id);
            return this.View(viewModel);
        }
    }
}
