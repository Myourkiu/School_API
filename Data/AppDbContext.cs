using Microsoft.EntityFrameworkCore;
using School_API.Model;

namespace School_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet <Student> Students { get; set; }
    }
}
