using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System.ComponentModel.DataAnnotations;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
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
            if (string.IsNullOrWhiteSpace(inputModel.Username) || inputModel.Username.Length < 5 || inputModel.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters long.");
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
                return this.Error("Passwords do not match.");
            }

            if (!this.usersService.IsEmailAvailable(inputModel.Email))
            {
                return this.Error("This email is already taken by another user");
            }

            if (!this.usersService.IsUsernameAvailable(inputModel.Username))
            {
                return this.Error("This username is already taken by another user");
            }

            this.usersService.CreateUser(inputModel);
            return this.Redirect("/users/login");
        }

        public HttpResponse Login()
        {
            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputModel inputModel)
        {
            var userId = this.usersService.GetUserId(inputModel.Username, inputModel.Password);

            if (userId == null)
            {
                return this.Error("Invalid username/password");
            }

            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/"); 
        }
    }
}
