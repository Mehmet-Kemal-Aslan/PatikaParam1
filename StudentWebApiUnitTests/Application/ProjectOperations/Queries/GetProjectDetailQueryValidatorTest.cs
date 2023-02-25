using FluentAssertions;
using StudentWebApi.Application.ProjectOperations.Queries;
using StudentWebApi.Application.ProjectOperations.Queries.GetProjectDetail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace StudentWebApiUnitTests.Application.ProjectOperations.Queries
{
    public class GetProjectDetailQueryValidatorTest
    {
        [Theory]
        [InlineData(0)]

        public void WhenInvalidInputIsGiven_Validator_ShouldBeReturnedErrors(int Id)
        {
            GetProjectDetailQuery query = new GetProjectDetailQuery(null, null);
            query.QueryId = Id;
            GetProjectDetailQueryValidator validator = new GetProjectDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void WhenValidInputIsGiven_Validator_ShouldNotBeReturnedErrors(int Id)
        {
            GetProjectDetailQuery query = new GetProjectDetailQuery(null, null);
            query.QueryId = Id;
            GetProjectDetailQueryValidator validator = new GetProjectDetailQueryValidator();
            var result = validator.Validate(query);
            result.Errors.Count.Should().Be(0);
        }
    }
}
