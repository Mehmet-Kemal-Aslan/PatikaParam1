using Microsoft.EntityFrameworkCore;

namespace StudentWebApi.Models
{
    public interface IStudentDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Mentor> Mentors { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<User> Users { get; set; }

        int SaveChanges();
    }
}
