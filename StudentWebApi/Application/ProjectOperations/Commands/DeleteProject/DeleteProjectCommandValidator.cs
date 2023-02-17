using FluentValidation;

namespace StudentWebApi.Application.ProjectOperations.Commands.DeleteProject
{
    public class DeleteProjectCommandValidator : AbstractValidator<DeleteProjectCommand>
    {
        public DeleteProjectCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
