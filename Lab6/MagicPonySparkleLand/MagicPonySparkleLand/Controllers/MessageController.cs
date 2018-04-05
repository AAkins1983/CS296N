using Microsoft.AspNetCore.Mvc;
using MagicPonySparkleLand.Repositories;
using MagicPonySparkleLand.Models;
using System;

namespace MagicPonySparkleLand.Controllers
{
    // This class will be instantiated by the MVC framework or by a unit test
    public class MessageController : Controller
    {
        private IMessageRepository messageRepo;

        public MessageController(IMessageRepository messageRepo)
        {
            this.messageRepo = messageRepo;
        }

        /* Action Methods that get info from the database */
        
        public ViewResult Index()
        {
            var messages = messageRepo.GetAllMessages();
            return View(messages);
        }

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Add(string messageText, string date, string user, string email)
        {
            Message message = new Message { MessageText = messageText, Date = DateTime.Parse(date)};
            if (user != null)
            {
                message.Users.Add(new User { Name = user, Email = email });
            }

            messageRepo.AddMessage(message);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            return View(messageRepo.GetMessageById(id));
        }

        [HttpPost]
        public RedirectToActionResult Edit(Message message)
        {
            messageRepo.Edit(message);
            return RedirectToAction("Index");
        }

        public RedirectToActionResult Delete(int id)
        {
            messageRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
