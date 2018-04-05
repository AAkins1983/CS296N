using Microsoft.EntityFrameworkCore;
using MPSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSL.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext context;

        public MessageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        /* Interface method implementations */

        public List<Message> GetAllMessages()
        {
            //List<Message> messages = context.Messages.ToList<Message>();
            //return messages;
            return context.Messages.Include(m => m.MessUsers).ToList();
        }

        public Message GetMessageBySubject(string subject)
        {
            return context.Messages.Include(m => m.MessUsers).First(m => m.Subject == subject);
        }

        public List<Message> GetMessagesByUser(MessUser mUser)
        {
            return (from mu in context.Messages
                    where mu.MessUsers.Contains(mUser)
                    select mu).Include(mu => mu.MessUsers).ToList();
        }

        public Message GetMessageById(int id)
        {
            return context.Messages.Include("MessUsers").First(m => m.MessageID == id);
        }

        public List<MessUser> GetMUsersByMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public int AddMessage(Message message)
        {
            // Add the message to the database
            context.Messages.Update(message);
            // Save the message so that it gets an ID (primary key value)
            context.SaveChanges();

            // Give each muser object a FK for the message
            // and add it to the database
            foreach (MessUser mu in message.MessUsers)
            {
                mu.MessageID = message.MessageID;
                context.MessUsers.Update(mu);
            }
            return context.SaveChanges();
        }

        public int Edit(Message message)
        {
            context.Messages.Update(message);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var messageFromDb = context.Messages.First(mu => mu.MessageID == id);
            context.Remove(messageFromDb);
            return context.SaveChanges();
        }

        public Message GetBookBySubject(string subject)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetMessagesByMUser(MessUser muser)
        {
            throw new NotImplementedException();
        }
    }
}
