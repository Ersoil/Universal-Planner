using Microsoft.EntityFrameworkCore;
using Universal_Planner.Componets.Models;

namespace Universal_Planner.Componets.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UTask> Tasks { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<UTag> Tags { get; set; }
        public DbSet<UTaskTag> TaskTags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=UniversalPlanner12.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Композитный ключ
            modelBuilder.Entity<UTaskTag>()
                .HasKey(tt => new { tt.TaskId, tt.TagId });

            // Настраиваем связи
            modelBuilder.Entity<UTaskTag>()
                .HasOne(tt => tt.Task)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TaskId);

            modelBuilder.Entity<UTaskTag>()
                .HasOne(tt => tt.Tag)
                .WithMany(t => t.TaskTags)
                .HasForeignKey(tt => tt.TagId);
        }
    }
}