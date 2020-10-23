using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class HomeController: Controller
    {
        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserSignedIn())
            {
                return this.View("/trips/all");
            }

            return this.View();
        }
    }
}
