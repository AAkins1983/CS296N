using Microsoft.AspNetCore.Mvc;
using MagicPonySparkleLand.Repositories;

namespace MagicPonySparkleLand.Controllers
{
    public class MessageController : Controller
    {
        private IMessageRepository messageRepository;

        public MessageController(IMessageRepository mRepo)
        {
            messageRepository = mRepo;
        }

        public ViewResult List() => View(messageRepository.Messages);
    }
}
