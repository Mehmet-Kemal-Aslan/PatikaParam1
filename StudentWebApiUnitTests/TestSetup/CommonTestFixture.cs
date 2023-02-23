using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentWebApi.Common;
using StudentWebApi.Models;

namespace StudentWebApiUnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public StudentDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFixture()
        {
            var options = new DbContextOptionsBuilder<StudentDbContext>()
                .UseInMemoryDatabase(databaseName: "StudentTestDb").Options;
            Context = new StudentDbContext(options);
            Context.Database.EnsureCreated();
            Context.AddStudents();
            Context.AddProjects();
            Context.AddMentors();
            Context.SaveChanges();

            Mapper = new MapperConfiguration(cfg => {cfg.AddProfile<MappingProfile>();}).CreateMapper();
        }
    }
}
