using System.ComponentModel.DataAnnotations.Schema;

namespace HackatonApi.Domain.Entities;

public class Product
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public string Name { get; set; } = null!;
    public double Amount { get; set; }
    public double Price { get; set; }

    public Company Company { get; set; } = null!;
}