using Microsoft.EntityFrameworkCore;

namespace CodeFirst1.Models
{
    public class StudentDBContext : DbContext
    {
        public StudentDBContext (DbContextOptions<StudentDBContext> options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
    }
}
