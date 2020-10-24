using SULS.ViewModels.Users;

namespace SULS.Services
{
    public interface IUsersService
    {
        //Will return the new user Id so we can sign him in
        string CreateUser(RegisterInputModel inputModel);

        string GetUserId(LoginInputViewModel inputViewModel);

        bool IsEmailAvailable(string email);

        bool IsUsernameAvailable(string username);
    }
}
