using Microsoft.AspNetCore.Mvc;
using Streamline.Models;
using Streamline.Repositories;

namespace Streamline.Controllers
{
    public class KiddoController : Controller
    {
        private IKiddoRepository kiddoRepo;

        public KiddoController(IKiddoRepository repo)
        {
            kiddoRepo = repo;
        }

        // GET: /<controller>/
        public ViewResult Index()
        {
            return View(kiddoRepo.GetAllKiddos());
        }

        public ViewResult TasksOfKiddo(Kiddo kiddo)
        {
            return View(kiddoRepo.GetTasksByKiddo(kiddo));
        }

        public ViewResult KiddosByName(string name)
        {
            return View(kiddoRepo.GetKiddoByName(name));
        }
    }
}
