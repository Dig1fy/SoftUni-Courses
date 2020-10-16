namespace BattleCards.Services
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        void IsUserValid(string username, string password);

        bool IsUsernameAvailable(string username);

        bool IsEmailAvaliable(string email);
    }
}
