using SUS.HTTP;
using SUS.MvcFramework;
using System.Linq;
using System.Text;

namespace MyMvcApp.Controllers
{
    public class HomeController : Controller
    {
        public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }
    }
}
