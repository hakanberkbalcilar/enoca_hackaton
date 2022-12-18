

namespace HackatonApi.Features.OrderOperations.Commands.CreateOrder;

public class CreateOrderModel
{
    public int CompanyId { get; set; }
    public int ProductId { get; set; }
    public string CustomerName { get; set; } = null!;
    public DateTime Date { get; set; }
}