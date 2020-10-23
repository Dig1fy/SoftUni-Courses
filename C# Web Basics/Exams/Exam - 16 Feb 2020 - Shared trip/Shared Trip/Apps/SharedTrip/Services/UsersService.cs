using SharedTrip.Data;
using SharedTrip.ViewModels.Users;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace SharedTrip.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateUser(RegisterInputModel inputModel)
        {
            var user = new User
            {
                Username = inputModel.Username,
                Email = inputModel.Email,
                Password = inputModel.Password
            };

            this.db.Add(user);
            this.db.SaveChanges();
        }

        public string GetUserId(string username, string password) =>
            this.db.Users.Where(x => x.Username == username || x.Password == password)
            .Select(y => y.Id)
            .FirstOrDefault();

        public bool IsEmailAvailable(string email) =>
            !this.db.Users.Any(x => x.Email == email);

        public bool IsUsernameAvailable(string username) =>
            !this.db.Users.Any(x => x.Username == username);
    }
}