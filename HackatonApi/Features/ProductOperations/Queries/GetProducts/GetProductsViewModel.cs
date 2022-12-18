
namespace HackatonApi.Features.ProductOperations.Queries.GetProducts;

public class GetProductsViewModel
{
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public double Amount { get; set; }
    public double Price { get; set; }
}