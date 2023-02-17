using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi.Operations.GetStudentDetail
{
    public class GetStudentDetailQuery
    {
        private readonly StudentDbContext _dbContext;
        private readonly IMapper _mapper;
        public int StudentId { get; set; }
        public GetStudentDetailQuery(StudentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        //An handler to see a student
        public StudentDetailViewModel Handle()
        {
            var student = _dbContext.Students.Include(x => x.Project).Where(student => student.Id == StudentId).SingleOrDefault();
            if (student == null)
                throw new InvalidOperationException("Öğrenci bulunamadı.");
            StudentDetailViewModel vm = _mapper.Map< StudentDetailViewModel>(student);

            return vm;
        }

        public class StudentDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Grade { get; set; }
            public string Note { get; set; }
            public string Project { get; set; }
        }
    }
}
