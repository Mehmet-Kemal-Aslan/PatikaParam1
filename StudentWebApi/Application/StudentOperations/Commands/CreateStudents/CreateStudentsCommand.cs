using AutoMapper;
using StudentWebApi.Models;

namespace StudentWebApi.Operations.CreateStudents
{
    public class CreateStudentsCommand
    {
        public CreateStudentModel Model { get; set; }
        private readonly StudentDbContext _dbContext;
        private readonly IMapper _mapper;
        public CreateStudentsCommand(StudentDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        // An Handler to create new student
        public void Handle()
        {
            var student = _dbContext.Students.SingleOrDefault(student => student.Name == Model.Name);
            if (student != null)
                throw new InvalidOperationException("Aynı öğrenci ikinci kez kaydedilemez!");
            student = _mapper.Map<Student>(Model);
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public class CreateStudentModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public int Grade { get; set; }
            public string Note { get; set; }
            public int ProjectId { get; set; }
        }
    }
}
