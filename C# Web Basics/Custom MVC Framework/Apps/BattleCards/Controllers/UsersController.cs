using BattleCards.Services;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace BattleCards.Controllers
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
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost("/Users/Login")]
        public HttpResponse DoLogin()
        {
            //We get the formData names from the views
            var username = this.Request.FormData["username"];
            var password = this.Request.FormData["password"];
            var userId = this.usersService.GetUserId(username, password);

            if (userId == null)
            {
                return this.Error("Invalid username or password. Please try again!");
            }

            this.SignIn(userId);
            return this.Redirect("/cards/all");
        }

        public HttpResponse Register()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost("/Users/Register")]
        public HttpResponse DoRegister()
        {
            var username = this.Request.FormData["username"];
            var email = this.Request.FormData["email"];
            var password = this.Request.FormData["password"];
            var confirmPassword = this.Request.FormData["confirmPassword"];

            if (string.IsNullOrWhiteSpace(username) || username.Length < 6 || username.Length > 20)
            {
                return this.Error("Username should between 5 and 20 characters long");
            }

            if (!Regex.IsMatch(username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed.");
            }

            if (password != confirmPassword)
            {
                return this.Error("Confirm passowrd seems to be different! Please type it again!");
            }

            if (!this.usersService.IsUsernameAvailable(username))
            {
                return this.Error("This username is already taken by another user.");
            }

            if (string.IsNullOrWhiteSpace(email) || !new EmailAddressAttribute().IsValid(email))
            {
                return this.Error("Invalid email.");
            }

            if (!this.usersService.IsEmailAvaliable(email))
            {
                return this.Error("This email is already taken by another user.");
            }

            if (password == null || password.Length < 6 || password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 characters long.");
            }

            var userId = this.usersService.CreateUser(username, email, password);

            return this.Redirect("/users/login");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Only logged-in users can log-out");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
