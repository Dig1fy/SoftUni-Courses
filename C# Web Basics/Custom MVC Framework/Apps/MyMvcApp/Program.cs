﻿using MyMvcApp.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyMvcApp
{
    class Program
    {
        static async Task Main(string[] args)
        {

            /*
            *  Route table
            */
            var routeTable = new List<Route>()
            {
                new Route( "/", new HomeController().Index ),
                new Route("/favicon.ico", new StaticFilesController().Favicon),
                new Route("/users/login", new UsersController().Login),
                new Route("/users/register", new UsersController().Register),
                new Route("/cards/add", new CardsController().Add),
                new Route("/cards/all", new CardsController().All),
                new Route("/cards/collection", new CardsController().Collection),
            };

            //The default port (defined in the CreateHost) is 80
            await Host.CreateHost(routeTable);
        }
    }
}
