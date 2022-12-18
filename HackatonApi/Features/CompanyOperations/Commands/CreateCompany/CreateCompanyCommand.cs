using System.Net;
using AutoMapper;
using HackatonApi.Core.DbOperations;
using HackatonApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Features.CompanyOperations.Commands.CreateCompany;

public class CreateCompanyCommand
{

    private IApplicationDbContext _context;
    private IMapper _mapper;

    public CreateCompanyModel Model { get; set; } = null!;

    public CreateCompanyCommand(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var company = _context.Companies.FirstOrDefault(x => x.Name.ToLower() == Model.Name.ToLower());

        if(company is not null)
            throw new HttpRequestException("Company with same name is already exist!", null, HttpStatusCode.Conflict);

        company = _mapper.Map<Company>(Model);

        _context.Companies.Add(company);
        _context.SaveChanges();
    }

}