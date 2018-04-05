using System.Threading.Tasks;
using MagicPonySparkleLand.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MagicPonySparkleLand.Controllers
{
    public class AdminController : Controller
    {
        private UserManager<NewUser> userManager;

        public AdminController(UserManager<NewUser> um)
        {
            userManager = um;
        }

        public IActionResult Index()
        {
            return View();
        }

        public ViewResult ShowUsers()
        {
            return View(userManager.Users);
        }


        // Action methods that modify the database

        public ViewResult NewUser() => View();

        [HttpPost]
        public async Task<IActionResult> NewUser(NewUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                NewUser user = new NewUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email
                };

                IdentityResult result
                    = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}