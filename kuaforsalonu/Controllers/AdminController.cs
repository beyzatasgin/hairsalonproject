using Microsoft.AspNetCore.Mvc;

namespace kuaforsalonu.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
