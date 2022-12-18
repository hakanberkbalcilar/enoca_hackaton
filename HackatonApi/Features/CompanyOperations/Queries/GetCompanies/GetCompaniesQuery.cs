using AutoMapper;
using HackatonApi.Core.DbOperations;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Features.CompanyOperations.Queries.GetCompanies;

public class GetCompaniesQuery
{
    private IApplicationDbContext _context;
    private IMapper _mapper;

    public int BranchId { get; set; }


    public GetCompaniesQuery(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public List<GetCompaniesViewModel> Handle()
    {
        var companyList = _context.Companies.OrderBy(x => x.Name);

        var vm = _mapper.Map<List<GetCompaniesViewModel>>(companyList);

        return vm;
    }
}