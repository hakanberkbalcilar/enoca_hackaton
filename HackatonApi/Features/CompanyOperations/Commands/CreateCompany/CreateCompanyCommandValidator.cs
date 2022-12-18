using FluentValidation;

namespace HackatonApi.Features.CompanyOperations.Commands.CreateCompany;

public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
{
    public CreateCompanyCommandValidator()
    {
        RuleFor(command => command.Model.Name).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.OrderStart).NotNull();
        RuleFor(command => command.Model.OrderEnd).NotNull();;
        RuleFor(command => command.Model.Status).NotNull();
    }
}