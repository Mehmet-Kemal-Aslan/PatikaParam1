using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using StudentWebApi.Application.ProjectOperations.Commands.DeleteProject;

namespace StudentWebApiUnitTests.Application.ProjectOperations.Commands.DeleteProject
{
    public class DeleteProjectCommandValidatorTest
    {
        [Theory]
        [InlineData(0)]

        public void WhenInvalidInputsAreGiven_Validator_ShouldBeReturnedErrors(int Id)
        {
            DeleteProjectCommand command = new DeleteProjectCommand(null);
            command.Id = Id;
            DeleteProjectCommandValidator validator = new DeleteProjectCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void WhenValidInputsAreGiven_Validator_ShouldNotBeReturnedErrors(int Id)
        {
            DeleteProjectCommand command = new DeleteProjectCommand(null);
            command.Id = Id;
            DeleteProjectCommandValidator validator = new DeleteProjectCommandValidator();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}
