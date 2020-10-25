using Git.Services;
using Git.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Git.Controllers
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
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Register(RegisterInputModel inputModel)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Username) || inputModel.Username.Length < 5 || inputModel.Username.Length > 20)
            {
                return this.Error("Username should be between 5 and 20 characters long.");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Email) || !new EmailAddressAttribute().IsValid(inputModel.Email))
            {
                return this.Error("Invalid e-mail address.");
            }

            if (string.IsNullOrWhiteSpace(inputModel.Password) || inputModel.Password.Length < 6 || inputModel.Password.Length > 20)
            {
                return this.Error("Password should be between 6 and 20 characters long.");
            }

            if (inputModel.Password != inputModel.ConfirmPassword)
            {
                return this.Error("Passwords do not match. Please check for typos!");
            }

            if (!this.usersService.IsEmailAvailable(inputModel.Email))
            {
                return this.Error("This email is already taken");
            }

            if (!this.usersService.IsUsernameAvailable(inputModel.Username))
            {
                return this.Error("This Username is already taken by another user.");
            }

            this.usersService.CreateUser(inputModel);
            return Redirect("/users/login");
        }

        public HttpResponse Login()
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Login(LoginInputViewModel inputModel)
        {
            if (this.IsUserSignedIn())
            {
                return this.Redirect("/");

            }
            var userId = this.usersService.GetUserId(inputModel);

            if (userId == null)
            {
                return this.Error("Invalid username/password");
            }

            this.SignIn(userId);
            return this.Redirect("/");
        }

        public HttpResponse Logout()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Error("Only logged-in users can log-out.");
            }

            this.SignOut();
            return this.Redirect("/");
        }
    }
}
