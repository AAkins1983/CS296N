using MagicPonySparkleLand.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace MagicPonySparkleLand.Repositories
{
    // The repository object will be injected into a Controller by a transient service (configured in Startup)
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
            return context.Messages.Include(m => m.Users).ToList();
        }

        public Message GetMessageById(int id)
        {
            return context.Messages.Include("Users").First(m => m.MessageID == id);
        }

        public List<Message> GetMessagesByUser(User user)
        {
            return (from m in context.Messages
                    where m.Users.Contains(user)
                    select m).Include(m => m.Users).ToList();
        }

        public int AddMessage(Message message)
        {
            // Add the message to the database
            context.Messages.Update(message);
            
            // Save the message so that it gets an ID (primary key value)
            context.SaveChanges();

            // Give each user object an FK for the message and add it to the database
            foreach (User u in message.Users)
            {
                u.MessageID = message.MessageID;
                context.Users.Update(u);
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
            var messageFromDb = context.Messages.First(a => a.MessageID == id);
            context.Remove(messageFromDb);
            return context.SaveChanges();
        }

        //private ApplicationDbContext context;

        //public MessageRepository(ApplicationDbContext ctx)
        //{
        //    context = ctx;
        //}

        //public IQueryable<Message> Messages => context.Messages;
        //public IQueryable<User> Users => context.Users;

        //private static List<ContactFormInfo> userInfo = new List<ContactFormInfo>();

        //public static IEnumerable<ContactFormInfo> UserInfo
        //{
        //    get
        //    {
        //        return userInfo;
        //    }
        //}

        //public List<Message> GetAllMessages()
        //{
        //    return context.Messages.Include(b => b.Users).ToList();
        //}

        //public static void AddInfo(ContactFormInfo info)
        //{
        //    userInfo.Add(info);
        //}
    }
}
