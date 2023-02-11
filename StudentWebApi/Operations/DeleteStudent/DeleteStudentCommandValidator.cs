using FluentValidation;

namespace StudentWebApi.Operations.DeleteStudent
{
    // Validation for DeleteStudentCommand
    public class DeleteStudentCommandValidator :AbstractValidator<DeleteStudentCommand>
    {
        public DeleteStudentCommandValidator()
        {
            RuleFor(command => command.StudentId).GreaterThan(0);
        }
    }
}
