using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Models;

namespace StudentWebApi.Operations
{
    public class GetStudentsQuery
    {
        private readonly StudentDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetStudentsQuery(StudentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // An handler to see all students
        public List<StudentViewModel>Handle()
        {
            var studentList = _dbContext.Students.Include(x => x.Project).OrderBy(x => x.Id).ToList<Student>();
            List<StudentViewModel> vm = _mapper.Map<List<StudentViewModel>>(studentList);
            
            return vm;
        }


        public class StudentViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Grade { get; set; }
            public string Note { get; set; }
            public string Project { get; set; }
        }
    }
}
