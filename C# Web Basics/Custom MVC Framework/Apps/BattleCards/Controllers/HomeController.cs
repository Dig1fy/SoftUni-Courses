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
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }

        internal HttpResponse About(HttpRequest request)
        {
            return this.View();
        }
    }
}
