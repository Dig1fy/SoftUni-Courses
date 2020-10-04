using SUS.HTTP;
using System.IO;
using System.Net;
using System.Text;

namespace SUS.MvcFramework
{
    public abstract class Controller
    {
       public HttpResponse View(string path)
        {
            var responseHtml = File.ReadAllText(path);

            //body length is always counted as number of bytes. 
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            //We;ve set default status code (Ok - 200) in the HttpResponse constructor
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
    }
}
