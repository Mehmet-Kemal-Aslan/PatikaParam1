using Microsoft.EntityFrameworkCore;

namespace StudentWebApi.Models
{
    public interface IStudentDbContext
    {
        DbSet<Student> Students { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Mentor> Mentors { get; set; }

        int SaveChanges();
    }
}
