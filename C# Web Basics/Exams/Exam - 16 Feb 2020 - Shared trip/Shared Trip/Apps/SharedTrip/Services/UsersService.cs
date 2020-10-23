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

        //public string GetUserId(string username, string password)
        //{

        //}

        //public bool IsEmailAvailable(string email)
        //{

        //}

        //public bool IsUsernameAvailable(string username)
        //{

        //}
    }
}