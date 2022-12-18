using AutoMapper;
using HackatonApi.Core.DbOperations;
using HackatonApi.Core.TokenOperations;
using HackatonApi.Core.TokenOperations.Model;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace HackatonApi.Features.UserOperations.Commands.CreateToken;

public class CreateTokenCommand
{

    private IApplicationDbContext _context;
    private IConfiguration _configuration;

    public CreateTokenModel Model { get; set; } = null!;

    public CreateTokenCommand(IApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var user = _context.Users
            .FirstOrDefault(x => x.Email == Model.Email && x.Password == Model.Password);
            
        if (user is null)
            throw new HttpRequestException("User not found!", null, HttpStatusCode.NotFound);

        TokenHandler handler = new TokenHandler(_configuration);


        Token token = handler.CreateAccessToken(user);

        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpireDate = token.ExpireDate;

        _context.SaveChanges();

        return token;
    }
}