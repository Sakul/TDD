using DemoSQLite.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoSQLite.Shared.Repositories
{
    public class UniversityDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }

        public UniversityDbContext(DbContextOptions<UniversityDbContext> options)
            : base(options)
        {
        }
    }
}
