using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentWebApi.Models;

namespace StudentWebApi.Operations
{
    public class GetStudentsQuery
    {
        private readonly StudentDbContext _dbContext;
        public GetStudentsQuery(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<StudentViewModel>Handle()
        {
            var studentList = _dbContext.Students.OrderBy(x => x.Id).ToList<Student>();
            List<StudentViewModel> vm = new List<StudentViewModel>();
            foreach (var student in studentList)
            {
                vm.Add(new StudentViewModel()
                {
                    Name = student.Name,
                    Surname = student.Surname,
                    Grade = student.Grade,
                });
            }
            return vm;
        }


        public class StudentViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Grade { get; set; }
        }
    }
}
