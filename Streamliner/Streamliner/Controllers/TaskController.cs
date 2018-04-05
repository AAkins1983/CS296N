using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Streamliner.Models;
using Streamliner.Repositories;

namespace Streamliner.Controllers
{
    // This class will be instantiated by the MVC framework or by a unit test
    public class TaskController : Controller
    {
        private ITaskRepository taskRepo;

        public TaskController(ITaskRepository taskRepo)
        {
            this.taskRepo = taskRepo;
        }

        /* Action Methods that get info from the database */

        [Authorize]
        public ViewResult Index()
        {
            var tasks = taskRepo.GetAllTasks();
            return View(tasks);
        }

        /* Action methods that modify the database */

        [Authorize]
        public ViewResult Add()
        {
            return View();
        }

        //[HttpPost]
        //public RedirectToActionResult Add(string description, string category, string kiddo)
        //{
        //    TaskItem task = new TaskItem { Description = description };
        //    if (kiddo != null)
        //    {
        //        task.Kiddos.Add(new Kiddo { Name = kiddo,  });
        //    }

        //    taskRepo.AddTask(task);

        //    return RedirectToAction("Index");
        //}
        [HttpPost]
        [Authorize]
        public RedirectToActionResult Add(string description, string category, int taskId)
        {
            taskRepo.AddTask(new TaskItem { Description = description, Category = category, TaskItemID = taskId });
            return RedirectToAction("Index", "Task");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View(taskRepo.GetTaskById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(TaskItem task)
        {
            taskRepo.Edit(task);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id)
        {
            taskRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
