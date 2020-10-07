using MyMvcApp.Controllers;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMvcApp
{
    class Startup
    {
        static async Task Main(string[] args)
        {
            //VIDEO 2:50:00 youtube
            /*
            *  Route table
            */
            var routeTable = new List<Route>();

            routeTable.Add(new Route("/", new HomeController().Index));
            routeTable.Add(new Route("/users/login", new UsersController().Login));
            routeTable.Add(new Route("/users/register", new UsersController().Register));
            routeTable.Add(new Route("/cards/add", new CardsController().Add));
            routeTable.Add(new Route("/cards/all", new CardsController().All));
            routeTable.Add(new Route("/cards/collection", new CardsController().Collection));

            routeTable.Add(new Route("/favicon.ico", new StaticFilesController().Favicon));
            routeTable.Add(new Route("/css/bootstrap.min.css", new StaticFilesController().BootstrapCss));
            routeTable.Add(new Route("/js/bootstrap.bundle.min.js", new StaticFilesController().BoostrapJs));
            routeTable.Add(new Route("/css/custom.css", new StaticFilesController().CustomCss));
            routeTable.Add(new Route("/js/custom.js", new StaticFilesController().CustomJs));

            //The default port (defined in the CreateHost) is 80
            await Host.CreateHost(routeTable);
        }
    }
}
