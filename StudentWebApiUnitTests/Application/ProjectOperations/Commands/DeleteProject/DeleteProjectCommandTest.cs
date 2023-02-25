using StudentWebApi.Application.ProjectOperations.Commands.DeleteProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Xunit;
using StudentWebApiUnitTests.TestSetup;
using StudentWebApi.Models;

namespace StudentWebApiUnitTests.Application.ProjectOperations.Commands.DeleteProject
{
    public class DeleteProjectCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly StudentDbContext _context;
        private readonly IMapper _mapper;
        public DeleteProjectCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenTheProjectIdDoesNotExist_InvalidOperation_ShouldBeReturn()
        {
            DeleteProjectCommand command = new DeleteProjectCommand(_context);
            command.Id = 0;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Silinecek proje bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Project_ShouldBeDeleted()
        {
            DeleteProjectCommand command = new DeleteProjectCommand(_context);
            Project project = new Project() { Name = "ExistingProject", IsActive = true };
            _context.Projects.Add(project);
            _context.SaveChanges();
            command.Id = project.ProjectId;
            FluentActions.Invoking(() => command.Handle()).Invoke();
            Project reuslt = _context.Projects.SingleOrDefault(x => x.ProjectId == command.Id);
            reuslt.Should().BeNull();
        }
    }
}
