using BlazorShop.Api.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BlazorShop.Api.Service
{
    public class TokenService
    {
        public static string GeneraterToken(Usuario user)
        {
            var TokenHandler = new JwtSecurityTokenHandler();
            var Key = Encoding.ASCII.GetBytes(setings.Secrety);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Email.ToString()),
                    new Claim(ClaimTypes.Role, user.GrupoUsuarioId.ToString())

                }),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Key),
                SecurityAlgorithms.HmacSha256Signature)
            };

            var Token = TokenHandler.CreateToken(tokenDescriptor);

            return TokenHandler.WriteToken(Token);

        }
    }
}
