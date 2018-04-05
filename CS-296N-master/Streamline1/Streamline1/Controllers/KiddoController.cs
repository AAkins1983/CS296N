using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streamline1.Models;
using Streamline1.Repositories;

namespace Streamline1.Controllers
{
    public class KiddoController : Controller
    {
        private IKiddoRepository kiddoRepo;

        public KiddoController(IKiddoRepository kiddoRepo)
        {
            this.kiddoRepo = kiddoRepo;
        }

        /* Action Methods that get info from the database */

        //[Authorize]
        public ViewResult Index()
        {
            var kiddos = kiddoRepo.GetAllKiddos();
            return View(kiddos);
        }

        /* Action methods that modify the database */

        //[Authorize(Roles = "member")]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Add(string name, string taskItem, string description, string category)
        {
            Kiddo kiddo = new Kiddo { Name = name };
            if (taskItem != null)
            {
                kiddo.TaskItems.Add(new TaskItem { Description = description, Category = category });
            }

            kiddoRepo.AddKiddo(kiddo);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View(kiddoRepo.GetKiddoById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(Kiddo kiddo)
        {
            kiddoRepo.Edit(kiddo);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id)
        {
            kiddoRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

