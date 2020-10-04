using SUS.HTTP;
using SUS.MvcFramework;
using System.IO;

namespace MyMvcApp.Controllers
{
    public class StaticFilesController : Controller
    {
        public HttpResponse Favicon(HttpRequest request)
        {
            return this.View("wwwroot/favicon.ico");
        }
    }
}
