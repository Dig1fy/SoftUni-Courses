namespace BattleCards.Services
{
    public interface IUsersService
    {
        //Returns user id
        string CreateUser(string username, string email, string password);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);
    }
}