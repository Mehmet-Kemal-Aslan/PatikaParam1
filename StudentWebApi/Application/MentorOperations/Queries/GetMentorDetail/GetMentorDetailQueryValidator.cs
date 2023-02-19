using FluentValidation;

namespace StudentWebApi.Application.MentorOperations.Queries.GetMentorDetail
{
    public class GetMentorDetailQueryValidator : AbstractValidator<GetMentorDetailQuery>
    {
        public GetMentorDetailQueryValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
