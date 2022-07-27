using Microsoft.EntityFrameworkCore;

namespace EntityframeworkCore6.Model
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<Students> Students { get; set; }

       
    }
}
