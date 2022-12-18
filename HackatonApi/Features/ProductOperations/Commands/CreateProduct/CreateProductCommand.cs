using System.Net;
using AutoMapper;
using HackatonApi.Core.DbOperations;
using HackatonApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Features.ProductOperations.Commands.CreateProduct;

public class CreateProductCommand
{

    private IApplicationDbContext _context;
    private IMapper _mapper;

    public CreateProductModel Model { get; set; } = null!;

    public CreateProductCommand(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var product = _context.Products.FirstOrDefault(x => x.Name == Model.Name);

        if(product is not null)
            throw new HttpRequestException("Product with same name is already exist!", null, HttpStatusCode.Conflict);

        product = _mapper.Map<Product>(Model);

        _context.Products.Add(product);

        _context.SaveChanges();
    }

}