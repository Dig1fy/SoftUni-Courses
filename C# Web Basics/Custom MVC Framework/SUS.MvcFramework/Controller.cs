using SUS.HTTP;
using SUS.MvcFramework.ViewEngine;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
        private SusViewEngine viewEngine;

        //Connect the view engine with each controller. This way we will be able to type ~Razor code dynamically 
        public Controller()
        {
            this.viewEngine = new SusViewEngine();
        }

        //We do not support view models yet, so we will pass null to the viewContent;
        object viewModel = null; 

        public HttpResponse View([CallerMemberName] string viewPath = null)
        {
            //The layout is always placed in Views/Shared/_Layout.html by convention
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.cshtml");

            layout = layout.Replace("@RenderBody()", "___WE REPLACE THE VIEW CONTENT IN HERE___");
            layout = this.viewEngine.GetHtml(layout, viewModel);

            //GetType will get the type of the invoked class. Then we take it's Name GetType().Name. (HomeController, CardsController, StaticFIlesController)
            var viewContent = System.IO.File.ReadAllText($"Views/{GetType().Name.Replace("Controller", string.Empty)}/{viewPath}.cshtml");

            //This is where we connect the view engine
            viewContent = this.viewEngine.GetHtml(viewContent, viewModel);

            var responseHtml = layout.Replace("___WE REPLACE THE VIEW CONTENT IN HERE___", viewContent);
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
