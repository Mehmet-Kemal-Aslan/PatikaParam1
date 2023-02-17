using FluentValidation;

namespace StudentWebApi.Operations.UpdateStudent
{
    // Validation for UpdateStudentCommand
    public class UpdateStudentCommandValidator : AbstractValidator<UpdateStudentCommand>
    {
        public UpdateStudentCommandValidator()
        {
            RuleFor(command => command.StudentId).GreaterThan(0);
            RuleFor(command => command.Model.ProjectId).GreaterThan(0);
            RuleFor(command => command.Model.Grade).NotEmpty().LessThan(15);
        }
        
    }
}
