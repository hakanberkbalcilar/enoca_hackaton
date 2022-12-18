using HackatonApi.Infrastructure.Model;

namespace HackatonApi.Features.CompanyOperations.Commands.CreateCompany;

public class CreateCompanyModel
{
    public string Name { get; set; } = null!;
    public Time OrderStart { get; set; } = null!;
    public Time OrderEnd { get; set; } = null!;
    public bool Status { get; set; }
}