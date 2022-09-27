using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Application.Common.Interfaces;
using Domain;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Auth;
public class JwtTokenGenerator : IJwtTokenGenerator
{
  public string GenerateToken(User user)
  {
    // create credentials
    var signingCredentials = new SigningCredentials(
                              new SymmetricSecurityKey(
                                Encoding.UTF8.GetBytes("super secret key")),
                                SecurityAlgorithms.HmacSha256);

    // create user claims
    var claims = new List<Claim>
    {
      new Claim(ClaimTypes.Name, user.UserName),
      new Claim(ClaimTypes.Email, user.Email),
      new Claim(ClaimTypes.NameIdentifier, user.Id),
    };

    // customize the token options
    var securityToken = new JwtSecurityToken(
        issuer: "",
        audience: "",
        expires: DateTime.UtcNow.AddDays(1),
        claims: claims,
        signingCredentials: signingCredentials);

    // generate token
    return new JwtSecurityTokenHandler().WriteToken(securityToken);
  }
}