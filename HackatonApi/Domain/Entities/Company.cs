using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackatonApi.Domain.Entities;

public class Company
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public TimeSpan OrderStart { get; set; }

    public TimeSpan OrderEnd { get; set; }

    public bool Status { get; set; }

    public List<Order> Orders { get; set; } = null!;
    public List<Product> Products { get; set; } = null!;
}