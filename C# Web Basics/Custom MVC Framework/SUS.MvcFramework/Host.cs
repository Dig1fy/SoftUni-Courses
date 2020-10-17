using Microsoft.CodeAnalysis.CSharp.Syntax;
using SUS.HTTP;
using SUS.HTTP.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            var routeTable = new List<Route>();
            var serviceCollection = new ServiceCollection();

            //We pass "application" so we can access the executing assembly ang get all types -> GetTypes().

            application.ConfigureServices(serviceCollection);
            application.Configure(routeTable);

            AutoGenerateStaticFiles(routeTable);
            AutoRegisterRoutes(routeTable, application, serviceCollection);

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

        private static void AutoRegisterRoutes(List<Route> routeTable, IMvcApplication application, IServiceCollection serviceCollection)
        {
            //routeTable.Add(new Route("/cards/add", HttpMethod.Get, new CardsController().Add));
            var controllerTypes = application.GetType().Assembly.GetTypes()
                .Where(x => !x.IsAbstract && x.IsClass && x.IsSubclassOf(typeof(Controller))); //we want only the Controller sub-classes

            //Get the methods of each controller
            foreach (var controllerType in controllerTypes)
            {
                //With the current methods, even only x.DeclaringType == controllerType will do the job. 
                var methods = controllerType.GetMethods()
                    .Where(x => x.IsPublic && !x.IsStatic && x.DeclaringType == controllerType
                    && !x.IsAbstract && !x.IsConstructor && !x.IsSpecialName);

                //For testing purpose
                //Console.WriteLine(controllerType.Name);
                foreach (var method in methods)
                {
                    var url = ($"/{controllerType.Name.Replace("Controller", string.Empty).ToLower()}/{method.Name.ToLower()}");
                    //Console.WriteLine(url);

                    //SUS.MvcFramework.HttpGetAttribute / HttpPostAttribute
                    var customAttribute = method.GetCustomAttributes(false)
                        .Where(x => x.GetType().IsSubclassOf(typeof(BaseHttpAttribute)))
                        .FirstOrDefault() as BaseHttpAttribute;

                    var httpMethod = HttpMethod.Get;

                    //Check if we've set custom url to the attribute [HttpPost("custom url")]
                    if (!string.IsNullOrWhiteSpace(customAttribute?.Url))
                    {
                        url = customAttribute.Url;
                    }

                    //Check if method is Get or Post
                    if (customAttribute != null)
                    {
                        httpMethod = customAttribute.Method;
                    }

                    if (!string.IsNullOrEmpty(customAttribute?.Url))
                    {
                        url = customAttribute.Url;
                    }

                    //We can afford to cast to HttpResponse since every action returns httpresponse. In ASP Core it will return IActionResult
                    routeTable.Add(new Route(url, httpMethod, request => ExecuteAction(request, controllerType, method, serviceCollection)));
                }
            }

        }

        private static HttpResponse ExecuteAction(HttpRequest request, Type controllerType, MethodInfo action, IServiceCollection serviceCollection)
        {
            var instance = serviceCollection.CreateInstance(controllerType) as Controller;
            instance.Request = request;
            var arguments = new List<object>();
            var parameters = action.GetParameters();
            foreach (var parameter in parameters)
            {
                var httpParamerValue = GetParameterFromRequest(request, parameter.Name);
                var parameterValue = Convert.ChangeType(httpParamerValue, parameter.ParameterType);
                if (parameterValue == null &&
                    parameter.ParameterType != typeof(string)
                    && parameter.ParameterType != typeof(int?))
                {
                    // complex type
                    parameterValue = Activator.CreateInstance(parameter.ParameterType);
                    var properties = parameter.ParameterType.GetProperties();
                    foreach (var property in properties)
                    {
                        var propertyHttpParamerValue = GetParameterFromRequest(request, property.Name);
                        var propertyParameterValue = Convert.ChangeType(propertyHttpParamerValue, property.PropertyType);
                        property.SetValue(parameterValue, propertyParameterValue);
                    }
                }

                arguments.Add(parameterValue);
            }

            var response = action.Invoke(instance, arguments.ToArray()) as HttpResponse;
            return response;
        }

        private static string GetParameterFromRequest(HttpRequest request, string parameterName)
        {
            parameterName = parameterName.ToLower();
            if (request.FormData.Any(x => x.Key.ToLower() == parameterName))
            {
                return request.FormData
                    .FirstOrDefault(x => x.Key.ToLower() == parameterName).Value;
            }

            if (request.QueryData.Any(x => x.Key.ToLower() == parameterName))
            {
                return request.QueryData
                    .FirstOrDefault(x => x.Key.ToLower() == parameterName).Value;
            }

            return null;
        }

        private static void AutoGenerateStaticFiles(List<Route> routeTable)
        {
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
        }
    }
}
