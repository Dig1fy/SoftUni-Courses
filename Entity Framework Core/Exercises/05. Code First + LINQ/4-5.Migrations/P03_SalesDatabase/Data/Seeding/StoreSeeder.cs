using P03_SalesDatabase.Data.Models;
using P03_SalesDatabase.Data.Seeding.Contracts;
using P03_SalesDatabase.IOManagement.Contracts;
using System.Linq;

namespace P03_SalesDatabase.Data.Seeding
{
    public class StoreSeeder : ISeeder
    {
        private readonly SalesContext dbContext;
        private readonly IWriter writer;

        public StoreSeeder(SalesContext context, IWriter writer)
        {
            this.dbContext = context;
             this.writer = writer;
        }
        public void Seed()
        {
            var stores = new Store[]
            {
                new Store() {Name = "Technomarket"},
                new Store() {Name = "PC Mania"},
                new Store() {Name = "Technopolis"},
                new Store() {Name = "JAR Computers"}
            };

            this.dbContext
                .Stores
                .AddRange(stores);

            this.dbContext
                .SaveChanges();

            this.writer.WriteLine($"{stores.Count()} stores were added to the database.");
        }
    }
}
