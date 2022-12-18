using HackatonApi.Infrastructure.Model;

namespace HackatonApi.Features.CompanyOperations.Commands.UpdateCompany;

public class UpdateCompanyModel
{
    public Time OrderStart { get; set; } = null!;
    public Time OrderEnd { get; set; } = null!;
    public bool Status { get; set; }
}