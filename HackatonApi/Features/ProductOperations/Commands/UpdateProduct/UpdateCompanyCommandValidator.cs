using FluentValidation;

namespace HackatonApi.Features.ProductOperations.Commands.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(command => command.Id).GreaterThan(0);
        RuleFor(command => command.Model.Name).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Amount).GreaterThanOrEqualTo(0);;
        RuleFor(command => command.Model.Price).GreaterThanOrEqualTo(0);
    }
}