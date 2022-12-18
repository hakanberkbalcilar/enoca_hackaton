using System.Net;
using HackatonApi.Core.DbOperations;
using HackatonApi.Core.TokenOperations;
using HackatonApi.Core.TokenOperations.Model;
using Microsoft.EntityFrameworkCore;

namespace ChefApi.Application.Accounting.UserOperations.Commands.RefreshToken;

public class RefreshTokenCommand
{

    private IApplicationDbContext _context;
    private IConfiguration _configuration;

    public string RefreshToken { get; set; } = null!;

    public RefreshTokenCommand(IApplicationDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }


    public Token Handle()
    {
        var user = _context.Users
            .FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
        if (user is null)
            throw new HttpRequestException("Refresh Token not found!", null, HttpStatusCode.NotFound);

        TokenHandler handler = new TokenHandler(_configuration);

        Token token = handler.CreateAccessToken(user);

        user.RefreshToken = token.RefreshToken;
        user.RefreshTokenExpireDate = token.ExpireDate;

        _context.SaveChanges();

        return token;
    }
}