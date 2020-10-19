using SULS.Data;
using System;
using System.Globalization;
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
            var problemMaxPoints = this.db.Problems
                .Where(x => x.Id == problemId)
                .Select(x => x.Points)
                .FirstOrDefault();

            var submission = new Submission()
            {
                Code = code,
                ProblemId = problemId,
                CreatedOn = DateTime.UtcNow.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                UserId = userId,
                AchievedResult = random.Next(0, problemMaxPoints + 1), //random [ ) 

            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var submission = this.db.Submissions.FirstOrDefault(x => x.Id == id);
            this.db.Submissions.Remove(submission);
            this.db.SaveChanges();
        }
    }
}
