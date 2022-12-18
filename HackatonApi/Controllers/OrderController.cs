using AutoMapper;
using FluentValidation;
using HackatonApi.Core.DbOperations;
using HackatonApi.Features.OrderOperations.Commands.CreateOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HackatonApi.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]s")]
public class OrderController : ControllerBase
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public OrderController(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    [HttpPost]
    public IActionResult CreateOrder(CreateOrderModel newOrder)
    {
        CreateOrderCommand command = new CreateOrderCommand(_context, _mapper);
        command.Model = newOrder;

        CreateOrderCommandValidator validator = new CreateOrderCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}