using System.ComponentModel.DataAnnotations.Schema;

namespace HackatonApi.Domain.Entities;

public class Order
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int CompanyId { get; set; }
    public int ProductId { get; set; }
    public string CustomerName { get; set; } = null!;
    public DateTime Date { get; set; }

    public Company Company { get; set; } = null!;
}