using BattleCards.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using System.Text;
using System.Security.Cryptography;
using SUS.MvcFramework;
using BattleCards.ViewModels.Users;

namespace BattleCards.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateUser(RegisterInputModel inputModel)
        {
            var user = new User
            {
                Username = inputModel.Username,
                Email = inputModel.Email,
                Password = ComputeHash(inputModel.Password),
            };
            this.db.Users.Add(user);
            this.db.SaveChanges();
            return user.Id;
        }

        public string GetUserId(LoginInputModel inputModel)
        {
            var user = this.db.Users.FirstOrDefault(x => x.Username == inputModel.Username);
            if (user?.Password != ComputeHash(inputModel.Password))
            {
                return null;
            }

            return user.Id;
        }

        public bool IsEmailAvailable(string email)
        {
            return !this.db.Users.Any(x => x.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return !this.db.Users.Any(x => x.Username == username);
        }

        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}