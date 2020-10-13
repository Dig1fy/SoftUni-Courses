using SUS.HTTP;
using SUS.MvcFramework;
using System.IO;
using System.Linq;
using System.Text;

namespace BattleCards.Controllers
{
    public class UsersController : Controller
    {
        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse DoLogin()
        {
            //TODO: read data
            //TODO: check user
            //TODO: log user
            //TODO: redirect to home page
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }
    }
}
