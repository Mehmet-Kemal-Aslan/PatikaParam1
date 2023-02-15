using FluentValidation;

namespace StudentWebApi.Application.ProjectOperations.Queries.GetProjectDetail
{
    public class GetProjectDetailValidator : AbstractValidator<GetProjectDetailQuery>
    {
        public GetProjectDetailValidator()
        {
            RuleFor(query => query.QueryId).GreaterThan(0);
        }
    }
}
