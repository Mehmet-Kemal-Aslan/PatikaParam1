using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;

namespace StudentWebApi.Operations.DeleteStudent
{
    public class DeleteStudentCommand
    {
        private readonly StudentDbContext _dbContext;
        public int StudentId { get; set; }
        public DeleteStudentCommand(StudentDbContext dbContext)
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

        public class DeleteStudentViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Grade { get; set; }
            public string Note { get; set; }
        }
    }
}
