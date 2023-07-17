using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebShop.Backoffice.Context;
using WebShop.Backoffice.Entities;
using WebShop.Backoffice.Service;

namespace WebShop.Backoffice.Controllers
{
    public class LoginController : Controller
    {

        private readonly AppDbContext _context;
        public LoginController(AppDbContext context)
        {
            _context = context;
                
        }


        [AllowAnonymous]
        public IActionResult Index(bool erroLogin)
        {

            if (erroLogin)
            {
                ViewBag.Erro = "Nickname e/ou senha estão incorretos";
            }
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(Usuario user)
        {
            var usuarioDB = (from x in _context.Usuarios
                             where x.Email == user.Email
                             select x).FirstOrDefault();

            if (!usuarioDB.Email.Equals(user.Email) ||
                !usuarioDB.Password.Equals(user.Password)
                )
            {
                return RedirectToAction("Index", new { erroLogin = true });
            }

            await new LoginService().Login(HttpContext, user);
            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public async Task<IActionResult> Sair()
        {
            await new LoginService().Logoff(HttpContext);
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Profile()
        {
            ViewBag.Permissoes = HttpContext.User.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value);
            return View();
        }


    }
}
