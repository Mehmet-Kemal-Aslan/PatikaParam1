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

        // An handler to update a student's grade and note.
        public void Handle()
        {
            var student = _dbContext.Students.SingleOrDefault(student => student.Id == StudentId);
            if (student == null)
                throw new InvalidOperationException("Güncellenecek öğrenci bulunamadı.");
            student.ProjectId = Model.ProjectId != default ? Model.ProjectId : student.ProjectId;
            student.Grade = Model.Grade != default ? Model.Grade : student.Grade;
            student.Note = Model.Note != default ? Model.Note : student.Note;
            _dbContext.SaveChanges();
        }

        public class StudentUpdateViewModel
        {
            public int Grade { get; set; }
            public string Note { get; set; }
            public int ProjectId { get; set; }
        }
    }
}
