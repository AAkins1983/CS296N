using MagicPonySparkleLand.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicPonySparkleLand.Repositories
{
    public class FakeMessageRepository : IMessageRepository
    {
        List<Message> messages = new List<Message>();

        public FakeMessageRepository()
        {
            Message message = new Message { MessageText = "Message #1!", Date = DateTime.Parse("01/01/2001") }; // month/day/year
            message.Users.Add(new User { Name = "Gidget" });
            messages.Add(message);

            message = new Message { MessageText = "Message #2!", Date = DateTime.Parse("05/05/2005") };
            message.Users.Add(new User { Name = "Elmo" });
            messages.Add(message);

            message = new Message { MessageText = "Message #3!", Date = DateTime.Parse("10/10/2010") };
            message.Users.Add(new User { Name = "Talula" });
            messages.Add(message);
        }

        public List<Message> GetAllMessages()
        {
            return messages;
        }

        public Message GetMessageById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessagesByUser(User user)
        {
            return (from m in messages
                    where m.Users.Contains(user)
                    select m).ToList();
        }

        public int AddMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public int Edit(Message message)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        //public IQueryable<Message> Messages => new List<Message>
        //{
        //    new Message {MessageText = "Message #1!", Date = DateTime.Parse("01/01/2001") },
        //    new Message {MessageText = "Message #2!", Date = DateTime.Parse("05/05/2005") },
        //    new Message {MessageText = "Message #3!", Date = DateTime.Parse("10/10/2010") },
        //}.AsQueryable<Message>();

        //public IQueryable<User> Users => new List<User>
        //{
        //    new User {Name = "Gidget", Email = "Gidget@email.com" },
        //    new User {Name = "Elmo", Email = "Elmo@sesame.street" },
        //    new User {Name = "Talula", Email = "Talula@yahoo.com" },
        //}.AsQueryable<User>();
    }
} 
