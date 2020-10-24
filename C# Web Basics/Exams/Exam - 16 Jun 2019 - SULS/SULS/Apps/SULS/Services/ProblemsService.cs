using SULS.Data;
using SULS.ViewModels.Home;
using SULS.ViewModels.Problems;
using System.Collections.Generic;
using System.Linq;

namespace SULS.Services
{
    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(CreateProblemInputModel inputModel)
        {
            var problem = new Problem
            {
                Name = inputModel.Name,
                Points = inputModel.Points,
            };

            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public IEnumerable<HomePageViewModel> GetAll()
        {
            return this.db.Problems.Select(x => new HomePageViewModel
            {
                Id = x.Id,
                Count = x.Submissions.Count(),
                Name = x.Name
            }).ToArray();
        }

        public string GetNameById(string id)
        {
            var problemName = this.db.Problems.Where(x => x.Id == id)
                .Select(y => y.Name)
                .FirstOrDefault();

            return problemName;
        }

        public ProblemViewModel getProblemById(string id)
        {
            return this.db.Problems.Where(x => x.Id == id)
                .Select(x => new ProblemViewModel
                {
                    Name = x.Name,
                    Submissions = x.Submissions.Select(s => new SubmissionViewModel
                    {
                        CreatedOn = s.CreatedOn,
                        SubmissionId = s.Id,
                        AchievedResult = s.AchievedResult,
                        Username = s.User.Username,
                        MaxPoints = x.Points,
                    })
                }).FirstOrDefault();
        }
    }
}
