using Microsoft.EntityFrameworkCore;

namespace TRPO_pr12.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=sql.ects;Database=TRPO_pr12;User Id = student_10; Password = student_10; TrustServerCertificate = True; ");
        }
    }
}
