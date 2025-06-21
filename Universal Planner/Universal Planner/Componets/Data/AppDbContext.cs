using Microsoft.EntityFrameworkCore;
using Universal_Planner.Componets.Models;

namespace Universal_Planner.Componets.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UTask> Tasks { get; set; }
        // Добавьте другие DbSet для UTag и Uuser по мере необходимости

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=UniversalPlanner1.db");
        }
    }
}