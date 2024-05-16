using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WhoWantsToBeAMillionaire.Models;

namespace WhoWantsToBeAMillionaire.Utilities
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite($"Data Source={ConfigurationManager.ConnectionStrings["Default"].ConnectionString}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasNoKey();
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
