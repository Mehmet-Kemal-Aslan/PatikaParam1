using StudentWebApi.Models;

namespace StudentWebApi.Operations.DeleteStudent
{
    public class DeleteStudentCommand
    {
        private readonly IStudentDbContext _dbContext;
        public int StudentId { get; set; }
        public DeleteStudentCommand(IStudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // An handler to delete student
        public void Handle()
        {
            var student = _dbContext.Students.Where(student => student.Id == StudentId).SingleOrDefault();
            if (student == null)
                throw new InvalidOperationException("Silinecek öğrenci bulunamadı.");
            _dbContext.Students.Remove(student);
            _dbContext.SaveChanges();
        }
    }
}
