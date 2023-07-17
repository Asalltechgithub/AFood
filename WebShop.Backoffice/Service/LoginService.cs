using System.Net.Http;
using System.Net;
using WebShop.Backoffice.Entities;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace WebShop.Backoffice.Service
{
    public class LoginService
    {

        public async Task Login(HttpContext ctx, Usuario user)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.Email));
            claims.Add(new Claim(ClaimTypes.Role, user.GrupoUsuarioId.ToString()));

            var claimsIdentity =
                new ClaimsPrincipal(
                    new ClaimsIdentity(
                        claims,
                        CookieAuthenticationDefaults.AuthenticationScheme
                    )
                );

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTime.Now.AddHours(8),
                IssuedUtc = DateTime.Now
            };


            await ctx.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsIdentity, authProperties);
        }

        public async Task Logoff(HttpContext ctx)
        {
            await ctx.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
