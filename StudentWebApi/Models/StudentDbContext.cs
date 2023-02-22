using Microsoft.EntityFrameworkCore;

namespace StudentWebApi.Models
{
    public class StudentDbContext : DbContext, IStudentDbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options)
            : base(options) { }
        public DbSet<Student> Students { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Mentor> Mentors { get; set; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
