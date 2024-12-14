using kuaforsalonu.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace kuaforsalonu.Controllers
{
    public class LoginController : Controller
    {
        private readonly Kuaforsalonu _db;
        public LoginController(Kuaforsalonu db)
        {
            _db = db;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Login(Admin p) 
        {
            var bilgiler=_db.Admin.FirstOrDefault(x=>x.Eposta==p.Eposta && x.Sifre==p.Sifre);
            if(bilgiler!=null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,p.Eposta)
                };
                var userIdentity= new ClaimsIdentity(claims,"Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Kullanıcı");
            } 
            return View();
        }
    }
}
