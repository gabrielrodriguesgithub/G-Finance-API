using Microsoft.IdentityModel.Tokens;
using SistemaGerenciamentoFinançasAPI.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SistemaGerenciamentoFinançasAPI.Services
{
    public class TokenService
    {
        private IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GerarToken(Usuario user)
        {
            var claims = new[]
            {
                new Claim("username", user.UserName),
                new Claim("id", user.Id),
                new Claim("loginTimestamp", DateTime.UtcNow.ToString())

            };

            var handler = new JwtSecurityTokenHandler();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenConfig = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(double.Parse(_config["Jwt:ExpiryInMinutes"])),
                signingCredentials: creds);

            var token = handler.WriteToken(tokenConfig);

            return token;
        }
    }
}
