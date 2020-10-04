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
            var responseHtml = "<h1>HOME PAGE says \"Woooho\"</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;

            //body length is always counted as number of bytes. 
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            //We;ve set default status code (Ok) in the HttpResponse constructor
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
        public HttpResponse About(HttpRequest request)
        {
            var responseHtml = "<h1>This actually works!...ABOUT PAGE </h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
