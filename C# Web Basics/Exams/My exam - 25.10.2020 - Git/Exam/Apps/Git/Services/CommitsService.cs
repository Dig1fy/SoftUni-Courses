using Git.Data;
using Git.ViewModels.Commits;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Git.Services
{
    public class CommitsService : ICommitsService
    {
        private readonly ApplicationDbContext db;

        public CommitsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public string CreateCommit(string description, string id, string userId, string repoId)
        {
            var repo = this.db.Repositories.Where(x => x.Commits.Any(y => y.Id == id)).FirstOrDefault() ;
            
            var creator = this.db.Users.Where(x => x.Id == userId).FirstOrDefault();

            var commit = new Commit
            {
                CreatedOn = DateTime.UtcNow,
                Description = description,
                CreatorId = creator.Id,
                RepositoryId = repoId, 
            };

            this.db.Commits.Add(commit);
            this.db.SaveChanges();
            return commit.Id;
        }

        public void Delete(string id, string userId)
        {
            var commit = this.db.Commits.Where(x => x.Id == id).FirstOrDefault();

            if (commit.CreatorId == userId)
            {
                this.db.Commits.Remove(commit);
                this.db.SaveChanges();
            }
        }

        public IEnumerable<CommitsViewModel> GetAll()
        {
            var commits = this.db.Commits.Select(x => new CommitsViewModel
            {
                Id = x.Id,
                CreatedOn = x.CreatedOn ,
                Description = x.Description,
                Repository = x.Repository.Name
            }).ToArray();

            return commits;
        }

        

        public string GetNameById(string id)
        {
            var name = this.db.Repositories.Where(x => x.Id == id)
                 .Select(y => y.Name)
                 .FirstOrDefault();

            return name;
        }

        
    }
}
