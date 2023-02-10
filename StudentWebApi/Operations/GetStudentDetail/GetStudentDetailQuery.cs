using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;

namespace StudentWebApi.Operations.GetStudentDetail
{
    public class GetStudentDetailQuery
    {
        private readonly StudentDbContext _dbContext;
        public int StudentId { get; set; }
        public GetStudentDetailQuery(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public StudentDetailViewModel Handle()
        {
            var student = _dbContext.Students.Where(student => student.Id == StudentId).SingleOrDefault();
            if (student == null)
                throw new InvalidOperationException("Öğrenci bulunamadı.");
            StudentDetailViewModel vm = new StudentDetailViewModel();
            vm.Name = student.Name;
            vm.Surname = student.Surname;
            vm.Grade = student.Grade;
            vm.Note = student.Note;

            return vm;
        }

        public class StudentDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Grade { get; set; }
            public string Note { get; set; }
        }
    }
}
