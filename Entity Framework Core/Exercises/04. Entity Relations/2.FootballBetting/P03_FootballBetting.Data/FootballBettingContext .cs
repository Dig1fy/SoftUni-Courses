using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using P03_FootballBetting.Data.Models;
using System;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {

        }

        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>(entity =>
            {
                entity.HasKey(t => t.TeamId);

                entity.Property(t => t.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);

                entity.Property(t => t.LogoUrl)
                .IsRequired(true)
                .IsUnicode(false);

                entity.Property(t => t.Initials)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(3);

                entity.HasOne(team => team.PrimaryKitColor)
                .WithMany(color => color.PrimaryKitTeams)
                .HasForeignKey(t => t.PrimaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.SecondaryKitColor)
                .WithMany(c => c.SecondaryKitTeams)
                .HasForeignKey(t => t.SecondaryKitColorId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(t => t.Town)
                .WithMany(town => town.Teams)
                .HasForeignKey(team => team.TownId);
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(c => c.ColorId);

                entity.Property(c => c.Name)
                .IsRequired(true)
                .HasMaxLength(50)
                .IsUnicode(false);
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.HasKey(t => t.TownId);

                entity.Property(t => t.Name)
                .HasMaxLength(50)
                .IsUnicode(true);

                entity.HasOne(t => t.Country)
                .WithMany(c => c.Towns)
                .HasForeignKey(t => t.CountryId);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasKey(c => c.CountryId);

                entity.Property(c => c.Name)
                .IsRequired(true)
                .IsUnicode(true)
                .HasMaxLength(50);
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasKey(p => p.PlayerId);

                entity.Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(true);

                entity.HasOne(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey(p => p.TeamId);

                entity.HasOne(p => p.Position)
                .WithMany(pos => pos.Players)
                .HasForeignKey(p => p.PositionId);
            });

            modelBuilder.Entity<Position>(entity =>
            {
                entity.HasKey(p => p.PositionId);

                entity.Property(p => p.Name)
                .HasMaxLength(50);
            });

            modelBuilder.Entity<PlayerStatistic>(entity =>
            {
                entity.HasKey(ps => new { ps.PlayerId, ps.GameId });

                entity.HasOne(ps => ps.Game)
                .WithMany(g => g.PlayerStatistics)
                .HasForeignKey(ps => ps.GameId);

                entity.HasOne(ps => ps.Player)
                .WithMany(p => p.PlayerStatistics)
                .HasForeignKey(ps => ps.PlayerId);
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(g => g.GameId);

                entity.Property(g => g.Result)
                .HasMaxLength(20);

                entity.HasOne(g => g.HomeTeam)
                .WithMany(ht => ht.HomeGames)
                .HasForeignKey(g => g.HomeTeamId)
                .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(g => g.AwayTeam)
                .WithMany(at => at.AwayGames)
                .HasForeignKey(g => g.AwayTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<Bet>(entity =>
            {
                entity.HasKey(b => b.BetId);

                entity.HasOne(b => b.Game)
                .WithMany(g => g.Bets)
                .HasForeignKey(b => b.GameId);

                entity.HasOne(b => b.User)
                .WithMany(u => u.Bets)
                .HasForeignKey(b => b.UserId);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.UserId);

                entity.Property(u => u.Username)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);

                entity.Property(u => u.Password)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);

                entity.Property(u => u.Email)
                .HasMaxLength(50)
                .IsRequired(true)
                .IsUnicode(false);

                entity.Property(u => u.Name)
                .HasMaxLength(50)
                .IsUnicode(false);

            });
        }
    }
}
