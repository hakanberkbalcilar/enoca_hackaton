using FluentValidation;

namespace HackatonApi.Features.OrderOperations.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(command => command.Model.CompanyId).GreaterThan(0);
        RuleFor(command => command.Model.ProductId).GreaterThan(0);
        RuleFor(command => command.Model.CustomerName).MinimumLength(3).MaximumLength(50);
        RuleFor(command => command.Model.Date).GreaterThanOrEqualTo(DateTime.Now);
    }
}