using SULS.Services;
using SULS.ViewModels.Home;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;

namespace SULS.Controllers
{
    public class HomeController: Controller
    {
        private readonly IProblemsService problemsService;

        public HomeController(IProblemsService problemsService)
        {
            this.problemsService = problemsService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                var problemsViewModel = this.problemsService.GetAll();

                //We have 3 overloads to pass View => View(), View(inputModel), View(inputModel, path)
                return this.View(problemsViewModel, "IndexLoggedIn");
            }

            return this.View(); //Views/Home(HomeController)/Index (Action name -> Index)
        }

        
       
    }
}
