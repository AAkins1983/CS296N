using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MPSL.Models;

namespace MPSL.Controllers
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

        public ViewResult ShowAccounts()
        {
            return View(userManager.Users);
        }

        // Action methods that modify the database

        public ViewResult CreateAccount() => View();

        [HttpPost]
        public async Task<IActionResult> CreateAccount(AccountViewModel model)
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
