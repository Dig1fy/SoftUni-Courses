using SUS.HTTP;
using System.Linq;
using System.Text;

namespace MyMvcApp.Controllers
{
    public class UsersController
    {
        public HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>LOGIN !!!!!</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
        public HttpResponse Register(HttpRequest request)
        {
            var responseHtml = "<h1>REGISTER !!!!!</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
