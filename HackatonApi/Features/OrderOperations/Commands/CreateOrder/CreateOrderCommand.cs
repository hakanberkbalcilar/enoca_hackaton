using System.Net;
using AutoMapper;
using HackatonApi.Core.DbOperations;
using HackatonApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Features.OrderOperations.Commands.CreateOrder;

public class CreateOrderCommand
{

    private IApplicationDbContext _context;
    private IMapper _mapper;

    public CreateOrderModel Model { get; set; } = null!;

    public CreateOrderCommand(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var company = _context.Companies.Include(x => x.Products).FirstOrDefault(x => x.Id == Model.CompanyId);
        if(company is null)
            throw new HttpRequestException("Company not found!", null, HttpStatusCode.NotFound);

        if(!company.Status)
            throw new HttpRequestException("Company is not verified!", null, HttpStatusCode.BadRequest);
        
        var now = DateTime.Now;

        if(!(company.OrderStart <= now.TimeOfDay && company.OrderEnd >= now.TimeOfDay))
            throw new HttpRequestException($"Company accept orders between {company.OrderStart} - {company.OrderEnd}!", null, HttpStatusCode.BadRequest);


        Console.WriteLine(Model.ProductId);
        var product = company.Products.FirstOrDefault(x => x.Id == Model.ProductId);

        if(product is null)
            throw new HttpRequestException("Product not found!", null, HttpStatusCode.NotFound);
    

        var order = _mapper.Map<Order>(Model);

        _context.Orders.Add(order);

        _context.SaveChanges();
    }

}