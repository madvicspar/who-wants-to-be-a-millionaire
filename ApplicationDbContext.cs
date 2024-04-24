using Microsoft.EntityFrameworkCore;

namespace WhoWantsToBeAMillionaire
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=D:\\vikto\\source\\repos\\WhoWantsToBeAMillionaire\\WhoWantsToBeAMillionaire.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().HasNoKey();
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Player> Players { get; set; }
    }
}
