using SUS.HTTP;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var server = new HttpServer();

            /*
             *  Route table
             */
            server.AddRoute("/", HomePage);

            server.AddRoute("/about", About);

            server.AddRoute("/favicon.ico", Favicon);

            server.AddRoute("/users/login", Login);

            //If we don't "await" here, the app will close after receiving the first client. Now, it will keep listening (tcpListener). 
            await server.StartAsync(80);

        }
        static HttpResponse HomePage(HttpRequest request)
        {
            var responseHtml = "<h1>HOME PAGE says \"Woooho\"</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;

            //body length is always counted as number of bytes. 
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);

            //We;ve set default status code (Ok) in the HttpResponse constructor
            var response = new HttpResponse("text/html", responseBodyBytes);
            
            return response;
        }
        static HttpResponse About(HttpRequest request)
        {
            var responseHtml = "<h1>This actually works!...ABOUT PAGE </h1>";            
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
        static HttpResponse Login(HttpRequest request)
        {
            var responseHtml = "<h1>LOGIN !!!!!</h1>" + request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }
        static HttpResponse Favicon(HttpRequest request)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vnd.microsoft.icon", fileBytes);
            return response;
        }
    }
}
