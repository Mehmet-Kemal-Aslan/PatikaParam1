using FluentAssertions;
using StudentWebApi.Application.ProjectOperations.Commands.CreateProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentWebApiUnitTests.Application.ProjectOperations.Commands.CreateProject
{
    public class CreateProjectCommandValidatorTests
    {
        [Theory]
        [InlineData("a")]
        [InlineData("")]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnedErrors(string ProjectName)
        {
            //arrange
            CreateProjectCommand command = new CreateProjectCommand(null);
            command.Model = new CreateProjectViewModel()
            {
                ProjectName = ProjectName
            };

            //act
            CreateProjectCommandValidator validator = new CreateProjectCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData("Rastgele")]
        public void WhenInvalidInputsAreGiven_Validator_ShouldNotBeReturnedErrors(string ProjectName)
        {
            //arrange
            CreateProjectCommand command = new CreateProjectCommand(null);
            command.Model = new CreateProjectViewModel()
            {
                ProjectName = ProjectName
            };

            //act
            CreateProjectCommandValidator validator = new CreateProjectCommandValidator();
            var result = validator.Validate(command);

            //assert
            result.Errors.Count.Should().Be(0);
        }
    }
}
