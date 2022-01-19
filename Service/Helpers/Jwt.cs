using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Service.Entities;

namespace Service.Helpers;

public class Jwt
{
    private readonly AppSettings _AppSettings;

    public Jwt(IOptions<AppSettings> appSettings)
    {
        _AppSettings = appSettings.Value;
    }

    public string GenerateJwtToken(User entity)
    {
        var key = Encoding.ASCII.GetBytes(_AppSettings.Secret);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, entity.Name),
                    new Claim(ClaimTypes.Sid, entity.Id.ToString()),
                    new Claim(ClaimTypes.Email, entity.Username),
                    new Claim(ClaimTypes.Role, entity.Role)
                }
            ),
            Expires = DateTime.UtcNow.AddHours(_AppSettings.LoginTokenExpirationHour),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
