using SULS.Data;
using System;
using System.Linq;

namespace SULS.Services
{
    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;
        private readonly Random random;

        public SubmissionsService(ApplicationDbContext db, Random random)
        {
            this.db = db;
            this.random = random;
        }
        public void Create(string code, string userId, string problemId)
        {
            var problemMaxPoints = this.db.Problems.FirstOrDefault(x => x.Id == problemId).Points;

            var submission = new Submission()
            {
                Code = code,
                ProblemId = problemId,
                CreatedOn = DateTime.UtcNow ,
                UserId = userId,
                AchievedResult = random.Next(0, problemMaxPoints + 1), //random [ ) 

            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }
    }
}
