using Microsoft.EntityFrameworkCore;
using TransvitiTestProject.Models;

namespace TransvitiTestProject.DbContextHandler
{
    public class StudentDbContext: DbContext
    {
        public DbSet<Student> Students { get; set; } 

        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options)
        {
        }
    }
}
