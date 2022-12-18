

namespace HackatonApi.Features.ProductOperations.Commands.UpdateProduct;

public class UpdateProductModel
{
    public string Name { get; set; } = null!;
    public double Amount { get; set; }
    public double Price { get; set; }
}