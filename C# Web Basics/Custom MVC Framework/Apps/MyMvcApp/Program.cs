using MyMvcApp.Controllers;
using SUS.HTTP;
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
            server.AddRoute("/", new HomeController().Index);

            server.AddRoute("/favicon.ico", new StaticFilesController().Favicon);

            server.AddRoute("/users/login", new UsersController().Login);

            server.AddRoute("/users/register", new UsersController().Register);

            server.AddRoute("/cards/add", new CardsController().Add);

            server.AddRoute("/cards/all", new CardsController().All);

            server.AddRoute("/cards/collection", new CardsController().Collection);

            //If we don't "await" here, the app will close after receiving the first client. Now, it will keep listening (tcpListener). 
            await server.StartAsync(80);

        }
    }
}
