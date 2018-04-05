using Microsoft.AspNetCore.Mvc;

namespace MagicPonySparkleLand.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
