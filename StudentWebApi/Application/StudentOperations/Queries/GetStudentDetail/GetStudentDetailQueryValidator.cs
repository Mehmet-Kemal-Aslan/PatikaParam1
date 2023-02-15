using FluentValidation;

namespace StudentWebApi.Operations.GetStudentDetail
{
    // Validation for GetStudentDetailQuery
    public class GetStudentDetailQueryValidator : AbstractValidator<GetStudentDetailQuery>
    {
        public GetStudentDetailQueryValidator()
        {
            RuleFor(command => command.StudentId).GreaterThan(0);
        }
    }
}
