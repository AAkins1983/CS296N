using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MPSL.Models;

namespace MPSL.Controllers
{
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

        /* Action methods that modify the database */

        [HttpGet]
        public ViewResult Add()
        {
            return View();
        }

        [HttpPost]
        public RedirectToActionResult Add(string text, string date, string subject, string user, string email)
        {
            Message message = new Message { MessageText = text, Date = DateTime.Parse(date), Subject = subject };
            if (user != null)
            {
                message.MessUsers.Add(new MessUser { Email = email, Username = user });
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