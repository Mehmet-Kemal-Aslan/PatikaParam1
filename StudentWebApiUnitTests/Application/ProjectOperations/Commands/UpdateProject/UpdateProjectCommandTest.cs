using System;
using AutoMapper;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using StudentWebApi.Models;
using StudentWebApiUnitTests.TestSetup;
using StudentWebApi.Application.ProjectOperations.Commands.UpdateProject;
using static StudentWebApi.Application.ProjectOperations.Commands.UpdateProject.UpdateProjectCommand;

namespace StudentWebApiUnitTests.Application.ProjectOperations.Commands.UpdateProject
{
    public class UpdateProjectCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly StudentDbContext _context;
        private readonly IMapper _mapper;
        public UpdateProjectCommandTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenTheProjectIdDoesNotExist_InvalidOperation_ShouldBeReturn()
        {
            UpdateProjectCommand command = new UpdateProjectCommand(_context);
            command.Id = 0;
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Güncellenecek proje bulunamadı.");
        }

        [Fact]
        public void WhenAlreadyExistProjectIsGiven_InvalidOperation_ShouldBeReturn()
        {
            UpdateProjectCommand command = new UpdateProjectCommand(_context);
            Project project = new Project() { Name = "ExistingProject", IsActive = true};
            _context.Projects.Add(project);
            _context.SaveChanges();
            command.Id = 1;
            command.Model = new UpdateProjectViewModel() { Name = project.Name, IsActive = project.IsActive };
            FluentActions.Invoking(() => command.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Aynı isimli bir proje zaten mevcut.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Project_ShouldBeUpdated()
        {
            UpdateProjectCommand command = new UpdateProjectCommand(_context);
            UpdateProjectViewModel model = new UpdateProjectViewModel() { Name = "UniqueName", IsActive = true };
            command.Model = model;
            command.Id = 1;
            FluentActions.Invoking(() => command.Handle()).Invoke();
            Project ? project = _context.Projects.SingleOrDefault(x => x.ProjectId == command.Id); 
            project.Should().NotBeNull();
        }
    }
}
