using AutoMapper;
using FluentAssertions;
using StudentWebApi.Application.ProjectOperations.Commands.CreateProject;
using StudentWebApi.Models;
using StudentWebApiUnitTests.TestSetup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentWebApiUnitTests.Application.ProjectOperations.Commands.CreateProject
{
    public class CreateProjectCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly StudentDbContext _context;
        private readonly IMapper _mapper;
        public CreateProjectCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenAlreadyexistProjectNameIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange
            var project = new Project() { Name = "WhenAlreadyexistProjectNameIsGiven_InvalidOperationException_ShouldBeReturn", IsActive = true };
            _context.Projects.Add(project);
            _context.SaveChanges();

            CreateProjectCommand command = new CreateProjectCommand(_context);
            command.Model = new CreateProjectViewModel() { ProjectName = project.Name };

            //act & assert
            FluentActions
                .Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Proje zaten mevcut.");
        }
    }
}
