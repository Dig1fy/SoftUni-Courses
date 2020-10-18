using SULS.Services;
using SULS.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

namespace SULS.Controllers
{
    public class UsersController: Controller
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
                            //These params names come from the view (Users/Login.cshtml)
        public HttpResponse Login(string username, string password)
        {
            var userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username/password");
            }

            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Register()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (string.IsNullOrWhiteSpace(input.Username) || input.Username.Length < 5 || input.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters long");
            }

            if (!this.usersService.IsUsernameAvailable(input.Username))
            {
                return this.Error("This username is already taken");
            }

            if (string.IsNullOrWhiteSpace(input.Email) || !new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Invalid email address");
            }

            if (string.IsNullOrWhiteSpace(input.Password) || input.Password.Length < 6 || input.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters long");
            }

            if (input.Password != input.ConfirmPassword)
            {
                return this.Error("\"Password\" doest not match \"ConfirmPassword\"");
            }

            if (!this.usersService.IsEmailAvailable(input.Email))
            {
                return this.Error("This email is already taken");
            }

            this.usersService.CreateUser(input.Username, input.Email, input.Password);
            return this.Redirect("/users/login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
