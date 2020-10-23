using SharedTrip.ViewModels.Users;

namespace SharedTrip.Services
{
    public interface IUsersService
    {
        void CreateUser(RegisterInputModel inputModel);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvailable(string email);

    }
}
