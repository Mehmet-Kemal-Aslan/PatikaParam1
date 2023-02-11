using FluentValidation;

namespace StudentWebApi.Operations.DeleteStudent
{
    public class DeleteStudentCommandValidator :AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(command => command.StudentId).GreaterThan(0);
        }
    }
}
