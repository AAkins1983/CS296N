using Microsoft.AspNetCore.Mvc;

namespace Streamliner.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
