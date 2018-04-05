using CommunityInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace CommunityInfo.Controllers
{
    public class QuizController : Controller
    {
        [HttpGet]
        public ViewResult Quiz()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Quiz(QuizInfo model)
        {
            int numCorrect = 0;

            if (model.Question1 == "a")
            {
                ViewData["Message"] = "You got it right!";
                ViewData["NumCorrect"] = numCorrect += 1;
            }
            if (model.Question2 == "a")
            {
                ViewData["Message"] = "You got it right!";
                ViewData["NumCorrect"] = numCorrect += 1;
            }
            if (model.Question3 == "c")
            {
                ViewData["Message"] = "You got it right!";
                ViewData["NumCorrect"] = numCorrect += 1;
            }
            if (model.Question4 == "c")
            {
                ViewData["Message"] = "You got it right!";
                ViewData["NumCorrect"] = numCorrect += 1;
            }
            if (model.Question5 == "c")
            {
                ViewData["Message"] = "You got it right!";
                ViewData["NumCorrect"] = numCorrect += 1;
            }
            else
            {
                ViewData["Message"] = "Sorry, wrong answer.";
            }
            return View();
        }
    }
}
