using BattleCards.Services;
using BattleCards.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BattleCards.Controllers
{
    class UsersController : Controller
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
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (inputModel.Username == null || inputModel.Username.Length < 5 || inputModel.Username.Length > 20)
            {
                return this.Error("Invalid username. The username should be between 5 and 20 characters.");
            }

            if (!Regex.IsMatch(inputModel.Username, @"^[a-zA-Z0-9\.]+$"))
            {
                return this.Error("Invalid username. Only alphanumeric characters are allowed.");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Email) || !new EmailAddressAttribute().IsValid(inputModel.Email))
            {
                return this.Error("Invalid email.");
            }

            if (inputModel.Password == null || inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                return this.Error("Invalid password. The password should be between 6 and 20 characters.");
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Error("Passwords should be the same.");
            }

            if (!this.usersService.IsUsernameAvailable(inputModel.Username))
            {
                return this.Error("This username is already taken.");
            }

            if (!this.usersService.IsEmailAvailable(inputModel.Email))
            {
                return this.Error("This email is already taken.");
            }

            this.usersService.CreateUser(inputModel);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel inputModel)
        {
            var userId = this.usersService.GetUserId(inputModel);

            if (userId == null)
            {
                return this.Error("Invalid username/password");
            }

            this.SignIn(userId);
            return this.Redirect("/cards/all");
        }
    }
}
