using CommunityInfo.Models;
using MagicPonySparkleLand.Models;
using System.Collections.Generic;
using System.Linq;

namespace MagicPonySparkleLand.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private ApplicationDbContext context;
        
        public MessageRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Message> Messages => context.Messages;
        public IQueryable<User> Users => context.Users;

        private static List<ContactFormInfo> userInfo = new List<ContactFormInfo>();

        public static IEnumerable<ContactFormInfo> UserInfo
        {
            get
            {
                return userInfo;
            }

        }

        public static void AddInfo(ContactFormInfo info)
        {
            userInfo.Add(info);
        }
    }
}
