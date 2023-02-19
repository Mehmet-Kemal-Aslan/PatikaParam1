using FluentValidation;

namespace StudentWebApi.Application.MentorOperations.Commands.UpdateMentor
{
    public class UpdateMentorCommandValidator : AbstractValidator<UpdateMentorCommand>
    {
        public UpdateMentorCommandValidator()
        {
            RuleFor(command => command.Model.ProjectId).GreaterThan(0);
        }
    }
}
