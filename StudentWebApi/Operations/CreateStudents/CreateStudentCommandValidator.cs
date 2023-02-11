using FluentValidation;
using System;

namespace StudentWebApi.Operations.CreateStudents
{
    // Validation for CreateStudentCommand
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentsCommand>
    {
        public CreateStudentCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty();
            RuleFor(command => command.Model.Grade).NotEmpty().LessThan(15);
        }
    }
}
