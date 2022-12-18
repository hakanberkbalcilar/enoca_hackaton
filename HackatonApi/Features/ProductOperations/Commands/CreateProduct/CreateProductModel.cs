

namespace HackatonApi.Features.ProductOperations.Commands.CreateProduct;

public class CreateProductModel
{
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public double Amount { get; set; }
    public double Price { get; set; }
}