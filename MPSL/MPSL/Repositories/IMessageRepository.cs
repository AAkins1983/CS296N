using System.Collections.Generic;

namespace MPSL.Models
{
    public interface IMessageRepository
    {
        List<Message> GetAllMessages();
        Message GetBookBySubject (string subject);
        Message GetMessageById(int id);
        List<Message> GetMessagesByMUser(MessUser muser);
        List<MessUser> GetMUsersByMessage(Message message);
        int AddMessage(Message message);
        int Edit(Message message);
        int Delete(int id);
    }
}
