using System.Net;
using AutoMapper;
using HackatonApi.Core.DbOperations;
using HackatonApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Features.CompanyOperations.Commands.UpdateCompany;

public class UpdateCompanyCommand
{

    private IApplicationDbContext _context;
    private IMapper _mapper;

    public int Id { get; set; }
    public UpdateCompanyModel Model { get; set; } = null!;

    public UpdateCompanyCommand(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var company = _context.Companies.FirstOrDefault(x => x.Id == Id);

        if(company is null)
            throw new HttpRequestException("Company not found!", null, HttpStatusCode.NotFound);
        
        company.OrderStart = company.OrderStart != default ? Model.OrderStart.ToTimeSpan() : company.OrderStart!;
        company.OrderEnd = company.OrderEnd != default ? Model.OrderEnd.ToTimeSpan() : company.OrderEnd!;
        company.Status = company.Status != default ? Model.Status : company.Status;

        _context.SaveChanges();
    }

}