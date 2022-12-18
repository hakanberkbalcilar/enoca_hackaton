using HackatonApi.Infrastructure.Model;

namespace HackatonApi.Features.CompanyOperations.Queries.GetCompanies;

public class GetCompaniesViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public Time OrderStart { get; set; } = null!;
    public Time OrderEnd { get; set; } = null!;
    public bool Status { get; set; }
}