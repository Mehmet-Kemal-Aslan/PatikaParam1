using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using StudentWebApi.Application.ProjectOperations.Queries;
using StudentWebApi.Models;
using StudentWebApiUnitTests.TestSetup;
using Xunit;

namespace StudentWebApiUnitTests.Application.ProjectOperations.Queries
{
    public class GetProjectDetailQueryTest : IClassFixture<CommonTestFixture>
    {
        private readonly StudentDbContext _context;
        private readonly IMapper _mapper;
        public GetProjectDetailQueryTest(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }

        [Fact]
        public void WhenTheProjectIdDoesNotExist_InvalidOperation_ShouldBeReturn()
        {
            GetProjectDetailQuery query = new GetProjectDetailQuery(_context, _mapper);
            query.QueryId = 0;
            FluentActions.Invoking(() => query.Handle()).Should().Throw<InvalidOperationException>()
                .And.Message.Should().Be("Proje bulunamadı.");
        }

        [Fact]
        public void WhenValidInputsAreGiven_Project_ShouldBeDeleted()
        {
            GetProjectDetailQuery query = new GetProjectDetailQuery(_context, _mapper);
            query.QueryId = 1;
            FluentActions.Invoking(() => query.Handle()).Invoke();
            Project? project = _context.Projects.SingleOrDefault(x => x.ProjectId == query.QueryId);
            project.Should().NotBeNull();
        }
    }
}
