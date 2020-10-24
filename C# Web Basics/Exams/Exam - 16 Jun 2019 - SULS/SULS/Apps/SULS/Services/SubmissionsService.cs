using SULS.Data;
using SULS.ViewModels.Submissions;
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
        public void Create(string problemId, string userId, string code)
        {
            var maxPoints = this.db.Problems.Where(x => x.Id == problemId)
                .Select(y => y.Points)
                .FirstOrDefault();

            var submission = new Submission
            {
                ProblemId = problemId,
                Code = code,
                UserId = userId,
                AchievedResult = random.Next(0, maxPoints + 1),
                CreatedOn = DateTime.UtcNow.ToShortDateString()
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.Where(x => x.Id == id).FirstOrDefault();
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
