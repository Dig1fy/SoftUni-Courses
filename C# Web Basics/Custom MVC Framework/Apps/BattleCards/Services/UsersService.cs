using BattleCards.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore.Internal;
using System.Text;
using System.Security.Cryptography;
using BattleCards.Migrations;
using SUS.MvcFramework;

namespace BattleCards.Services
{
    public class UsersService : IUsersService
    {
        private readonly ApplicationDbContext db;

        public UsersService(ApplicationDbContext db)
        {
            this.db = db;
        }
        public void CreateUser(string username, string email, string password)
        {
            var user = new User
            {
                UserName = username,
                Email = email,
                Role = IdentityRole.User,
                Password = ComputeHash(password)
            };

            this.db.Users.Add(user);
            this.db.SaveChanges();
        }

        public bool IsEmailAvaliable(string email) =>
         !this.db.Users.Any(x => x.Email == email);

        public bool IsUsernameAvailable(string username) =>
            !this.db.Users.Any(x => x.UserName == username);

        public bool IsUserValid(string username, string password)
        {
            var user = this.db.Users.FirstOrDefault(x => x.UserName == username);
            return user.Password == ComputeHash(password);
        }
        private static string ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);
            using var hash = SHA512.Create();
            var hashedInputBytes = hash.ComputeHash(bytes);
            // Convert to text
            // StringBuilder Capacity is 128, because 512 bits / 8 bits in byte * 2 symbols for byte 
            var hashedInputStringBuilder = new StringBuilder(128);
            foreach (var b in hashedInputBytes)
                hashedInputStringBuilder.Append(b.ToString("X2"));
            return hashedInputStringBuilder.ToString();
        }
    }
}
