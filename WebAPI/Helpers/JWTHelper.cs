using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using WebAPI.Models;

namespace WebAPI.Helpers
{
  internal class JWTHelper
  {
    public static string GenerateAccessToken(IConfiguration configuration)
    {
      TokenOption tokenOption = configuration.GetSection("TokenOption").Get<TokenOption>();

      List<Claim> claims = new List<Claim>();

      JwtSecurityToken token = new JwtSecurityToken(
        issuer: tokenOption.Issuer,
        audience: tokenOption.Audience,
        notBefore: DateTime.Now,
        expires: DateTime.Now.AddDays(tokenOption.Expiration),
        signingCredentials: new SigningCredentials(
          new SymmetricSecurityKey(Convert.FromBase64String(tokenOption.Key)),
          SecurityAlgorithms.HmacSha256
        )
      );

      return new JwtSecurityTokenHandler().WriteToken(token);
    }
  }
}