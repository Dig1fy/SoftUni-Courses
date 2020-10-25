using Git.ViewModels.Users;

namespace Git.Services
{
    public interface IUsersService
    {
        string CreateUser(RegisterInputModel inputModel);

        string GetUserId(LoginInputViewModel inputViewModel);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);
    }
}
