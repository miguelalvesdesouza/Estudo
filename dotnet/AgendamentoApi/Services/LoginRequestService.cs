using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;

namespace AgendamentoApi.Services
{
    public class LoginRequestService
    {
        private readonly IConfiguration _config;

        public LoginRequestService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateJwtToken(string username)
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["JwtSettings:SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _config["JwtSettings:Issuer"],
                audience: _config["JwtSettings:Audience"],
                claims: new List<Claim> { new Claim(ClaimTypes.Name, username) },
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}