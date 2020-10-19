using SULS.Data;
using SULS.ViewModels.Home;
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

        public void Create(string name, int points)
        {
            this.db.Problems.Add(new Problem()
            {
                Name = name,
                Points = points
            });

            this.db.SaveChanges();
        }

        //We need a collection for all the problems, listed on the home page
        public IEnumerable<HomePageViewModel> GetAll()
        {
            var problems = this.db.Problems
                .Select(x => new HomePageViewModel()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Count = x.Submissions.Count()
                }).ToList();

            return problems;
        }

        public string GetNameById(string id)
        {
            var problemName = this.db.Problems
                .Where(x=>x.Id == id)
                .Select(y=>y.Name)
                .FirstOrDefault();

            return problemName;
        }
    }
}
