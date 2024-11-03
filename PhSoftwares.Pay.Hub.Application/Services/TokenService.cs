using PhSoftwares.Pay.Hub.Application.Interfaces.Services;
using PhSoftwares.Pay.Hub.Core.Entities;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace PhSoftwares.Pay.Hub.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly SymmetricSecurityKey _secretKey;
        public TokenService(IConfiguration configuration)
        {
            _secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:SecretKey"]));
        }
        public string CreateToken(User user)
        {
            throw new NotImplementedException();
        }
    }
}
