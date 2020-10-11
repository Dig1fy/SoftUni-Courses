using SUS.HTTP;
using SUS.HTTP.Enums;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            var routeTable = new List<Route>();

            // This will get all files put in wwwroot (do not forget to adjust to "Copy always"). -> Example: wwwroot\\css\\bootstrap\\min.css
            // Note that in the windows directory, the slash in opposite -> "\" instead of "/". We need to replace these and also remove "wwwroot" to get the path automatically
            var staticFiles = Directory.GetFiles("wwwroot", "*", SearchOption.AllDirectories);

            foreach (var staticFile in staticFiles)
            {
                // "wwwroot\\favicon.ico" => "/favicon.ico"
                var url = staticFile.Replace("wwwroot", string.Empty).Replace("\\", "/");
                routeTable.Add(new Route(url, HttpMethod.Get, (request) =>
                {
                    var fileContent = File.ReadAllBytes(staticFile);
                    //We get the file extension of each file (.cs/.html/.jpeg etc)
                    var fileExtension = new FileInfo(staticFile).Extension;

                    //Using the new "switch" syntax
                    var contentType = fileExtension switch 
                    {
                        ".txt" => "text/plain",
                        ".js" => "text/javascript",
                        ".css" => "text/css",
                        ".jpg" => "image/jpg",
                        ".jpeg" => "image/jpg",
                        ".png" => "image/png",
                        ".gif" => "image/gif",
                        ".ico" => "image/vnd.microsoft.icon",
                        ".html" => "text/html",
                        _ => "text/plain",
                    };

                    return new HttpResponse(contentType, fileContent, HttpStatusCode.Ok);
                }));
            }

            application.ConfigureServices();
            application.Configure(routeTable);

            //For debugging purposes
            System.Console.WriteLine("All registered routes");
            foreach (var route in routeTable)
            {
                System.Console.WriteLine($"{route.Method} => {route.Path}");
            }

            IHttpServer server = new HttpServer(routeTable);





            //If we don't "await" here, the app will close after receiving the first client. Now, it will keep listening (tcpListener). 
            await server.StartAsync(80);
        }
    }
}
