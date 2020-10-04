using SUS.HTTP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHost(List<Route> routeTable, int port = 80)
        {            
            var server = new HttpServer();

            foreach (var route in routeTable)
            {
                server.AddRoute(route.Path, route.Action);
            }



            //If we don't "await" here, the app will close after receiving the first client. Now, it will keep listening (tcpListener). 
            await server.StartAsync(80);
        }
    }
}
