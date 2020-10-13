using BattleCards.ViewModels;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Linq;
using System.Text;

namespace BattleCards.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {

            return this.View();
        }

        internal HttpResponse About()
        {
            return this.View();
        }
    }
}
