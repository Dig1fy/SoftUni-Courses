using BattleCards.ViewModels.Users;

namespace BattleCards.Services
{
    public interface IUsersService
    {
        //Returns user id
        string CreateUser(RegisterInputModel inputModel);

        bool IsEmailAvailable(string email);

        string GetUserId(LoginInputModel inputModel);

        bool IsUsernameAvailable(string username);
    }
}