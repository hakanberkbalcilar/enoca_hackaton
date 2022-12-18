using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HackatonApi.Core.TokenOperations.Model;
using HackatonApi.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace HackatonApi.Core.TokenOperations;

public class TokenHandler
{
    public IConfiguration Configuration { get; set; }

    public TokenHandler(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public Token CreateAccessToken(User user)
    {

        Token tokenModel = new Token();
        SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Token:SecurityKey"]!));
        SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        tokenModel.ExpireDate = DateTime.Now.AddMinutes(15);
        var claimList = new List<Claim>{
                    new Claim(ClaimTypes.PrimarySid, user.Id.ToString()),
                };

        JwtSecurityToken securityToken = new JwtSecurityToken(
            issuer: Configuration["Token:Issuer"],
            audience: Configuration["Token:Audience"],
            expires: tokenModel.ExpireDate,
            notBefore: DateTime.Now,
            signingCredentials: credentials,
            claims: claimList
        );

        JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

        tokenModel.AccessToken = tokenHandler.WriteToken(securityToken);
        tokenModel.RefreshToken = CreateRefreshToken();

        return tokenModel;
    }

    private string CreateRefreshToken()
    {
        return Guid.NewGuid().ToString();
    }
}