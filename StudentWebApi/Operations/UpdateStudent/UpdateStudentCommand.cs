using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;

namespace StudentWebApi.Operations.UpdateStudent
{
    public class UpdateStudentCommand
    {
        private readonly StudentDbContext _dbContext;
        public int StudentId { get; set; }
        public StudentUpdateViewModel Model { get; set; }
        public UpdateStudentCommand(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StudentUpdateViewModel Handle()
        {
            var student = _dbContext.Students.Where(student => student.Id == StudentId).SingleOrDefault();
            if (student == null)
                throw new InvalidOperationException("Güncellenecek öğrenci bulunamadı.");
            StudentUpdateViewModel vm = new StudentUpdateViewModel();
            student.Grade = Convert.ToInt32(Model.Grade);
            student.Note = Model.Note != default ? Model.Note : student.Note;
            _dbContext.SaveChanges();

            return vm;
        }

        public class StudentUpdateViewModel
        {
            public int Grade { get; set; }
            public string Note { get; set; }
        }
    }
}
