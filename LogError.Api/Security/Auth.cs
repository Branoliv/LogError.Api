using LogError.Domain.DTO;
using LogError.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LogError.Api.Security
{
    public class Auth
    {
        private readonly Token _token;

        public Auth(IOptions<Token> token)
        {
            _token = token?.Value;
        }

        public string GerarToken(UserDTO user)
        {
            if (user == null) return null;


            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.Id.ToString(),"Id"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString("N")),
                    new Claim("User",JsonConvert.SerializeObject(user))
                });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_token.Secret);

            var descriptor = new SecurityTokenDescriptor
            {
                Issuer = _token.Emissor,
                Audience = _token.ValidoEm,
                Expires = DateTime.UtcNow.AddHours(_token.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Subject = identity
            };

            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
