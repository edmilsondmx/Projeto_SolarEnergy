using System.Security.Claims;
using SolarEnergy.Domain.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using SolarEnergy.Domain.Security;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Extensions;

namespace SolarEnergy.Domain.Services;

public class TokenService
{
    public static string GenerateToken(User user)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Name, user.Nome),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Role, user.Role.GetDisplayName()),
        };
        return GenerateToken(claims);
    }
    public static string GenerateToken(IEnumerable<Claim> claims)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(Settings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
