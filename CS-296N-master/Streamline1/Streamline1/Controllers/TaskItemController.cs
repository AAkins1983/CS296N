using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Streamline1.Models;
using Streamline1.Repositories;
using System;

namespace Streamline1.Controllers
{
    public class TaskItemController : Controller
    {
        private ITaskItemRepository taskItemRepo;

        public TaskItemController(ITaskItemRepository repo)
        {
            taskItemRepo = repo;
        }

        /* Action methods */

        public ViewResult Index()
        {
            var taskItems = taskItemRepo.GetAllTasks();
            return View(taskItems);
        }

        //[Authorize(Roles = "member")]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        //[Authorize]
        public RedirectToActionResult Add(string description, string category, int kiddoid)
        {
            taskItemRepo.Add(new TaskItem { Description = description, Category = category, KiddoID = kiddoid });
            return RedirectToAction("Index", "TaskItem");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View("TaskEntry", taskItemRepo.GetTaskById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(String description, String category, int taskitemid, int kiddoid)
        {
            TaskItem taskItem = new TaskItem
            {
                Description = description,
                Category = category,
                TaskItemID = taskitemid,
                KiddoID = kiddoid
            };

            taskItemRepo.Edit(taskItem);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id)
        {
            taskItemRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}

