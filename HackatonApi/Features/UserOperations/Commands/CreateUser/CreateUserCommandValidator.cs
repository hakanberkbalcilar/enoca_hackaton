using FluentValidation;

namespace HackatonApi.Features.UserOperations.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(command => command.Model.Name).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Surname).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Email).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Password).MinimumLength(6).MaximumLength(16);
    }
}