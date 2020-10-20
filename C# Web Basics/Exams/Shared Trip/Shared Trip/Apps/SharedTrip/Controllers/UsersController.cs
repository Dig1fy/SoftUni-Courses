using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel model)
        {
            var userId = this.usersService.GetUserId(model.Username, model.Password);

            if (userId == null)
            {
                return this.Error("Invalid username/password");
            }

            this.SignIn(userId);

            return this.Redirect("/trips/all");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel model)
        {
            if (string.IsNullOrWhiteSpace(model.Username) || model.Username.Length < 5 || model.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters long.");
            }

            if (string.IsNullOrWhiteSpace(model.Email))
            {
                return this.Error("Invalid Email address");
            }

            if (string.IsNullOrWhiteSpace(model.Password) || model.Password.Length < 6 || model.Password.Length > 20)
            {
                return this.Error("Password should be between 5 and 20 characters long.");
            }

            if (model.Password != model.ConfirmPassword)
            {
                return this.Error("Passwords do not match");
            }

            if (!this.usersService.IsUsernameAvailable(model.Username))
            {
                return this.Error("This username is already taken.");
            }

            if (!this.usersService.IsEmailAvailable(model.Email))
            {
                return this.Error("This email is already taken.");
            }

            this.usersService.CreateUser(model.Username, model.Email, model.Password);

            return this.Redirect("/users/login");
        }

        public HttpResponse Logout()
        {

            this.SignOut();

            return this.Redirect("/");
        }
    }
}
