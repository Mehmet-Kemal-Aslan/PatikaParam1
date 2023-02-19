using FluentValidation;

namespace StudentWebApi.Application.MentorOperations.Commands.CreateMentor
{
    public class CreateMentorCommandValidator : AbstractValidator<CreateMentorCommand>
    {
        public CreateMentorCommandValidator()
        {
            RuleFor(command => command.Model.Name).NotEmpty().MinimumLength(3);
            RuleFor(command => command.Model.Surname).NotEmpty();
            RuleFor(command => command.Model.ProjectId).GreaterThan(0);
        }
    }
}
