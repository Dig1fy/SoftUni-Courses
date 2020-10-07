using SUS.HTTP;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SUS.MvcFramework
{
    public static class Host
    {
        public static async Task CreateHostAsync(IMvcApplication application, int port = 80)
        {
            var routeTable = new List<Route>();
            application.ConfigureServices();
            application.Configure(routeTable);

            IHttpServer server = new HttpServer(routeTable);

            



            //If we don't "await" here, the app will close after receiving the first client. Now, it will keep listening (tcpListener). 
            await server.StartAsync(80);
        }
    }
}
