using AutoMapper;
using FluentValidation;
using HackatonApi.Core.DbOperations;
using HackatonApi.Features.ProductOperations.Commands.CreateProduct;
using HackatonApi.Features.ProductOperations.Commands.UpdateProduct;
using HackatonApi.Features.ProductOperations.Queries.GetProducts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackatonApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]s")]
public class ProductController : ControllerBase
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public ProductController(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetProducts()
    {
        GetProductsQuery query = new GetProductsQuery(_context, _mapper);

        return Ok(query.Handle());
    }

    [HttpPost]
    public IActionResult CreateProduct(CreateProductModel newProduct)
    {
        CreateProductCommand command = new CreateProductCommand(_context, _mapper);
        command.Model = newProduct;

        CreateProductCommandValidator validator = new CreateProductCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct(int id, [FromBody] UpdateProductModel newProduct)
    {
        UpdateProductCommand command = new UpdateProductCommand(_context, _mapper);
        command.Id = id;
        command.Model = newProduct;

        UpdateProductCommandValidator validator = new UpdateProductCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}