using FluentValidation;

namespace StudentWebApi.Operations.GetStudentDetail
{
    public class GetStudentDetailQueryValidator : AbstractValidator<GetStudentDetailQuery>
    {
        public GetStudentDetailQueryValidator()
        {
            RuleFor(command => command.StudentId).GreaterThan(0);
        }
    }
}
