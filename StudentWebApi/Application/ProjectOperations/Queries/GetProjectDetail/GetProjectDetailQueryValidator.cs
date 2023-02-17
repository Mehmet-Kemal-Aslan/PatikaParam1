using FluentValidation;

namespace StudentWebApi.Application.ProjectOperations.Queries.GetProjectDetail
{
    public class GetProjectDetailQueryValidator : AbstractValidator<GetProjectDetailQuery>
    {
        public GetProjectDetailQueryValidator()
        {
            RuleFor(query => query.QueryId).GreaterThan(0);
        }
    }
}
