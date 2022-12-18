using FluentValidation;

namespace HackatonApi.Features.CompanyOperations.Commands.UpdateCompany;

public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
{
    public UpdateCompanyCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.OrderStart).NotNull();
        RuleFor(command => command.Model.OrderEnd).NotNull();;
        RuleFor(command => command.Model.Status).NotNull();
    }
}