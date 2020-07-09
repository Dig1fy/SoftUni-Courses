using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
        }

        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers{ get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configurations.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(c => c.Email)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.HasOne(s => s.Customer)
                .WithMany(c => c.Sales);

                entity.HasOne(s => s.Product)
                .WithMany(p => p.Sales);

                entity.HasOne(s => s.Store)
                .WithMany(st => st.Sales);

                //Instead of using DateTime.Now, we set the Date with default value coming from the database (Calling function GETDATE()).
                entity.Property(s => s.Date)
                .HasDefaultValueSql("GETDATE()");
                
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.Property(p => p.Description)
                .HasDefaultValue("No description");
            });
        } 
    }
}