using BattleCards.Services;
using SUS.HTTP;
using SUS.MvcFramework;

namespace BattleCards.Controllers
{
    class UsersController: Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(string username, string email, string password)
        {
            return this.Redirect("/users/login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }
    }
}
