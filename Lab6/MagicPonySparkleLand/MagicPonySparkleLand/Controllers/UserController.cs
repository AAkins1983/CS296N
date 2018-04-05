using System;
using MagicPonySparkleLand.Models;
using MagicPonySparkleLand.Repositories;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MagicPonySparkleLand.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepo;

        public UserController(IUserRepository uRepo)
        {
            userRepo = uRepo;
        }

        /* Action methods */

        public ViewResult Index()
        {
            var users = userRepo.GetAllUsers();
            return View(users);
        }

        [HttpPost]
        public RedirectToActionResult Add(string name, string email, int messageid)
        {
            userRepo.Add(new User { Name = name, Email = email, MessageID = messageid });
            return RedirectToAction("Index", "Message");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View("UserEntry", userRepo.GetUserById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(String name, String email, int userid, int messageid)
        {
            User user = new User
            {
                Name = name,
                Email = email,
                UserID = userid,
                MessageID = messageid
            };

            userRepo.Edit(user);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id)
        {
            userRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
