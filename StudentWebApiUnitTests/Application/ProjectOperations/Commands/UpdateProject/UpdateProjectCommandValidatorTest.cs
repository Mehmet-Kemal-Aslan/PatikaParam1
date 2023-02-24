using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using StudentWebApi.Application.ProjectOperations.Commands.CreateProject;
using StudentWebApi.Application.ProjectOperations.Commands.UpdateProject;
using Xunit;
using static StudentWebApi.Application.ProjectOperations.Commands.UpdateProject.UpdateProjectCommand;

namespace StudentWebApiUnitTests.Application.ProjectOperations.Commands.UpdateProject
{
    public class CreateProjectCommandValidatorTests
    {
        [Theory]
        [InlineData("a")]
        [InlineData("")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnedErrors(string ProjectName)
        {
            UpdateProjectCommand command = new UpdateProjectCommand(null);
            command.Model = new UpdateProjectViewModel()
            {
                Name = ProjectName
            };
            UpdateProjectCommandValidator validator = new UpdateProjectCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("Rastgele")]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnedErrors(string ProjectName)
        {
            UpdateProjectCommand command = new UpdateProjectCommand(null);
            command.Model = new UpdateProjectViewModel()
            {
                Name = ProjectName
            };
            UpdateProjectCommandValidator validator = new UpdateProjectCommandValidator();
            var result = validator.Validate(command);

            result.Errors.Count.Should().Be(0);
        }
    }
}
