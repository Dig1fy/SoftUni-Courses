using Git.Data;
using Git.ViewModels.Repositories;
using SUS.MvcFramework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class RepositoriesService : IRepositoriesService
    {
        private readonly ApplicationDbContext db;

        public RepositoriesService(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpPost]
        public string CreateRepo(string name, string repositoryType, string userId)
        {
            var ownerName = this.db.Users.Where(x => x.Id == userId).Select(y => y.Username).FirstOrDefault();
            var owner = this.db.Users.Where(x => x.Id == userId).FirstOrDefault();

            var repo = new Repository
            {
                Name = name,
                IsPublic = repositoryType == "Public" ? true : false,
                CreatedOn = DateTime.UtcNow,
                OwnerId = owner.Id,
                Commits = new HashSet<Commit>()
            };

            this.db.Repositories.Add(repo);
            this.db.SaveChanges();
            return repo.Id;
        }

        public IEnumerable<RepositoryViewModel> GetAll()
        {
            var repositories = this.db.Repositories.Select(x => new RepositoryViewModel
            {
                Id = x.Id,
                Commits = x.Commits.Count(),
                CreatedOn = x.CreatedOn,
                Name = x.Name,
                Owner = x.Owner.Username
            }).ToArray();

            return repositories;
        }
    }
}
