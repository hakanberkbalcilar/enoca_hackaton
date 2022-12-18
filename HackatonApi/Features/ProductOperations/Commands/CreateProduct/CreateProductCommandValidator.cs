using FluentValidation;

namespace HackatonApi.Features.ProductOperations.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(command => command.Model.CompanyId).GreaterThan(0);
        RuleFor(command => command.Model.Name).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Amount).GreaterThanOrEqualTo(0);
        RuleFor(command => command.Model.Price).GreaterThanOrEqualTo(0);
    }
}