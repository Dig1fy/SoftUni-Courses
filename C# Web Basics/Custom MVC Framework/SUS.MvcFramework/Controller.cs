using SUS.HTTP;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName] string viewPath = null)
        {
            //The layout is always placed in Views/Shared/_Layout.html by convention
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");

            //GetType will get the type of the invoked class. Then we take it's Name GetType().Name. (HomeController, CardsController, StaticFIlesController)
            var viewContent = System.IO.File.ReadAllText($"Views/{GetType().Name.Replace("Controller", string.Empty)}/{viewPath}.cshtml");

            var responseHtml = layout.Replace("@RenderBody()", viewContent);
            //body length is always counted as number of bytes. 
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            //We;ve set default status code (Ok - 200) in the HttpResponse constructor
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {
            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            var response = new HttpResponse(contentType, fileBytes);
            return response;
        }

        public HttpResponse Redirect(string path)
        {
            var response = new HttpResponse(HTTP.Enums.HttpStatusCode.Found);
            //In order to redirect, we need "location" 
            response.Headers.Add(new Header("Location", path));
            return response;
        }
    }
}
