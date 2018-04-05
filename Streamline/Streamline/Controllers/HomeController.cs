using Microsoft.AspNetCore.Mvc;
using Streamline.Repositories;

namespace Streamline.Controllers
{
    public class HomeController : Controller
    {
        private ITaskRepository taskRepo;

        public HomeController(ITaskRepository repo)
        {
            taskRepo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult Tasks()
        {
            var repo = new TaskRepository();
            var tasks = repo.GetAllTasks();
            return View(tasks);
        }
    }
}
