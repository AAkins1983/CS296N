using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPSL.Models;
using MPSL.Repositories;

namespace MPSL.Controllers
{
    public class UserController : Controller
    {
        private IUserRepository userRepo;

        public UserController(IUserRepository repo)
        {
            userRepo = repo;
        }

        /* Action methods */

        public ViewResult Index()
        {
            var musers = userRepo.GetAllMUsers();
            return View(musers);
        }

        [HttpPost]
        public RedirectToActionResult Add(string email, string username, int mId)
        {
            userRepo.Add(new MessUser { Email = email, Username = username, MessageID = mId });
            return RedirectToAction("Index", "Message");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View("UserEntry", userRepo.GetMUserById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(string email, string username, int userid, int messageid)
        {
            MessUser muser = new MessUser
            {
                Email = email,
                Username = username,
                MessUserID = userid,
                MessageID = messageid
            };

            userRepo.Edit(muser);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id)
        {
            userRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}