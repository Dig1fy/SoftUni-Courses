namespace BattleCards.Services
{
    public interface IUsersService
    {
        //Returns user id
        string CreateUser(string username, string email, string password);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvaliable(string email);
    }
}
