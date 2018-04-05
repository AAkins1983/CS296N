using CommunityInfo.Models;
using MagicPonySparkleLand.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CommunityInfo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public ViewResult History()
        {
            ViewData["Message"] = "Here is a brief history of the community.";

            return View();
        }

        public ViewResult Map()
        {
            ViewData["Message"] = "Here is a map of the community.";

            return View();
        }

        public ViewResult Info()
        {
            ViewData["Message"] = "Highlights of the community.";

            return View();
        }

        //[HttpGet]
        //public ViewResult ContactForm()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public ViewResult ContactForm(ContactFormInfo contactFormInfo)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        MessageRepository.AddInfo(contactFormInfo);
        //        return View("Thanks", contactFormInfo);
        //    }
        //    else
        //    {
        //        return View();
        //    }
        //}
    }
}
