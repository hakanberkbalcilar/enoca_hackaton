using System.Net;
using AutoMapper;
using HackatonApi.Core.DbOperations;
using HackatonApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace HackatonApi.Features.UserOperations.Commands.CreateUser;

public class CreateUserCommand
{

    private IApplicationDbContext _context;
    private IMapper _mapper;

    public CreateUserModel Model { get; set; } = null!;

    public CreateUserCommand(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }


    public void Handle()
    {
        var user = _context.Users.FirstOrDefault(x => x.Email == Model.Email);

        if(user is not null)
            throw new HttpRequestException("User with same email address is already exist!", null, HttpStatusCode.Conflict);

        user = _mapper.Map<User>(Model);

        _context.Users.Add(user);

        _context.SaveChanges();
    }

}