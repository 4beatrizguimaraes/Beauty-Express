using Microsoft.IdentityModel.Tokens;
using Modelos.Cliente;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dominio.Service
{
    public class TokenService
    {
        public string GerarToken(Cliente usuario)
        {
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime.Now.AddHours(4),
                Issuer = "Beauty",
                Audience = "Beauty",
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SDI23894GFWGFYGDF&%$*#JKDHFSHGDFYGDF_2387ENSDJ")),
                    SecurityAlgorithms.HmacSha256Signature),
            };

            var claims = new Claim[]
            {
                new Claim("name", usuario.Nome),
                new Claim("email", usuario.Email),
                new Claim("telefone", usuario.Telefone)
            };
            tokenDescriptor.Subject = new ClaimsIdentity(claims);

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public bool TokenEhValido(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var parametros = new TokenValidationParameters {
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("SDI23894GFWGFYGDF&%$*#JKDHFSHGDFYGDF_2387ENSDJ")),
                ValidIssuer = "Beauty",
                ValidAudience = "Beauty",
                ValidateLifetime = true };

            try
            {
                tokenHandler.ValidateToken(token, parametros, out var tokenValidado);
                return true;
            } 
            catch
            {
                return false;
            }
        }
    }
}
