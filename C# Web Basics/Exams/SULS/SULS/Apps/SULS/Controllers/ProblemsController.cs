using SULS.Services;
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
                return this.Redirect("/users/login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            if (string.IsNullOrWhiteSpace(name) || name.Length < 5 || name.Length > 20)
            {
                return this.Error("Problem's name should be between 5 and 20 characters long.");
            }

            if (points < 50 || points > 300)
            {
                return this.Error("Points should be between 50 and 300");
            }

            this.problemsService.Create(name, points);
            return this.Redirect("/");
        }

        //This Id comes from the form Path (query string)
        public HttpResponse Details(string id)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/users/login");
            }

            var viewModel = this.problemsService.GetModеlById(id);

            return this.View(viewModel);
        }

        
    }
}
