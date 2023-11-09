using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PersonWEBAPI.Application.Abstraction;
using PersonWEBAPI.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PersonWEBAPI.Application.Services;

public class TokenService : ITokenService<Person>
{
    private readonly IConfiguration _configuration;

    public TokenService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetToken(Person person)
    {
        var claims = new Claim[]
        {
            new(ClaimTypes.Email, "")
        };

        var token = new JwtSecurityToken(
            issuer: _configuration["JWT:IssuerKey"],
            audience: _configuration["JWT:AudienceKey"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(_configuration["JWT:AccessTokenLifeTime"])),
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                SecurityAlgorithms.HmacSha256Signature));

        return new JwtSecurityTokenHandler().WriteToken(token);



            
    }
}
