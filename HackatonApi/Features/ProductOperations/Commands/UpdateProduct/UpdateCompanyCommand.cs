using System.Net;
using AutoMapper;
using HackatonApi.Core.DbOperations;
using HackatonApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Features.ProductOperations.Commands.UpdateProduct;

public class UpdateProductCommand
{

    private IApplicationDbContext _context;
    private IMapper _mapper;

    public int Id { get; set; }
    public UpdateProductModel Model { get; set; } = null!;

    public UpdateProductCommand(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var product = _context.Products.FirstOrDefault(x => x.Id == Id);

        if(product is null)
            throw new HttpRequestException("Product not found!", null, HttpStatusCode.NotFound);
        
        product.Name = product.Name != default ? Model.Name : product.Name!;
        product.Amount = product.Amount != default ? Model.Amount : product.Amount;
        product.Price = product.Price != default ? Model.Price : product.Price;

        _context.SaveChanges();
    }

}