using FluentValidation;

namespace StudentWebApi.Application.ProjectOperations.Commands.UpdateProject
{
    public class UpdateProjectCommandValidator : AbstractValidator<UpdateProjectCommand>
    {
        public UpdateProjectCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);//.When(x => x.Model.Name.Trim() != String.Empty);
        }
    }
}
