using AutoMapper;
using ChefApi.Application.Accounting.UserOperations.Commands.RefreshToken;
using FluentValidation;
using HackatonApi.Core.DbOperations;
using HackatonApi.Features.UserOperations.Commands.CreateToken;
using HackatonApi.Features.UserOperations.Commands.CreateUser;
using Microsoft.AspNetCore.Mvc;

namespace HackatonApi.Controllers;

[ApiController]
[Route("api/[controller]s")]
public class UserController : ControllerBase
{
    private IApplicationDbContext _context;
    private IMapper _mapper;
    private readonly IConfiguration _configuration;

    public UserController(IApplicationDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    [HttpGet("RefreshToken")]
    public IActionResult RefreshToken([FromQuery] string refreshToken)
    {
        RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
        command.RefreshToken = refreshToken;

        return Ok(command.Handle());
    }

    [HttpPost("Connect/Token")]
    public IActionResult CreateToken(CreateTokenModel login)
    {
        CreateTokenCommand command = new CreateTokenCommand(_context, _configuration);
        command.Model = login;

        return Ok(command.Handle());
    }

    [HttpPost]
    public IActionResult CreateUser(CreateUserModel newUser)
    {
        CreateUserCommand command = new CreateUserCommand(_context, _mapper);
        command.Model = newUser;

        CreateUserCommandValidator validator = new CreateUserCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();

        return Ok();
    }
}