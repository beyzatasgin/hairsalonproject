using Microsoft.AspNetCore.Mvc;

namespace kuaforsalonu.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            //var yetkiid = HttpContext.Session.GetInt32("yetkiid");

           // HttpContext.Session.SetInt32("yetkiid", 1);

            return View();
        }
    }
}
