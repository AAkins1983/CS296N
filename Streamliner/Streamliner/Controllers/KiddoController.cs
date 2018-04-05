using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streamliner.Models;
using Streamliner.Repositories;
using System;

namespace Streamliner.Controllers
{
    public class KiddoController : Controller
    {
        private IKiddoRepository kiddoRepo;

        public KiddoController(IKiddoRepository repo)
        {
            kiddoRepo = repo;
        }

        /* Action methods */

        public ViewResult Index()
        {
            var kiddos = kiddoRepo.GetAllKiddos();
            return View(kiddos);
        }

        [HttpPost]
        [Authorize]
        public RedirectToActionResult Add(string name, int taskId)
        {
            kiddoRepo.Add(new Kiddo { Name = name, TaskItemID = taskId });
            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View("KiddoEntry", kiddoRepo.GetKiddoById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(String name, int kiddoid, int taskid)
        {
            Kiddo kiddo = new Kiddo
            {
                Name = name,
                KiddoID = kiddoid,
                TaskItemID = taskid
            };

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
