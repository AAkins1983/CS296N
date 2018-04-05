using MagicPonySparkleLand.Models;
using System.Collections.Generic;

namespace MagicPonySparkleLand.Repositories
{
    public interface IMessageRepository
    {
        List<Message> GetAllMessages();
        Message GetMessageById(int id);
        List<Message> GetMessagesByUser(User user);
        int AddMessage(Message message);
        int Edit(Message message);
        int Delete(int id);
    }
}
