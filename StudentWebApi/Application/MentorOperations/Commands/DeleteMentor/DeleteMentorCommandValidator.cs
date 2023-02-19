using FluentValidation;

namespace StudentWebApi.Application.MentorOperations.Commands.DeleteMentor
{
    public class DeleteMentorCommandValidator : AbstractValidator<DeleteMentorCommand>
    {
        public DeleteMentorCommandValidator()
        {
            RuleFor(command => command.Id).GreaterThan(0);
        }
    }
}
