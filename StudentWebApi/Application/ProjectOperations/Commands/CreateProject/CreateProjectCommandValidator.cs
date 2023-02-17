using FluentValidation;

namespace StudentWebApi.Application.ProjectOperations.Commands.CreateProject
{
    // Validation for CreateProjectCommand
    public class CreateProjectCommandValidator : AbstractValidator<CreateProjectCommand>
    {
        public CreateProjectCommandValidator()
        {
            RuleFor(command => command.Model.ProjectName).NotEmpty().MinimumLength(3);
        }
    }
}
