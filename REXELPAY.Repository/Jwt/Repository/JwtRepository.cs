using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using REXELPAY.Repository.Jwt.Repository.Interface;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace REXELPAY.Repository.Jwt.Repository
{
    public class JwtRepository : IJwtRepository
    {
        private IConfiguration _config;
        public JwtRepository(IConfiguration config)
        {
            _config = config;
        }
        public string GenerateJWTTokenAsync()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            expires: DateTime.Now.AddDays(1),
            signingCredentials: credentials
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
