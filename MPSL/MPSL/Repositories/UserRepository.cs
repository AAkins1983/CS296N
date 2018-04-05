using MPSL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MPSL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public UserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<MessUser> GetAllMUsers()
        {
            List<MessUser> musers = context.MessUsers.ToList<MessUser>();
            return musers;
        }

        public MessUser GetMUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public MessUser GetMUserById(int id)
        {
            return context.MessUsers.First(mu => mu.MessUserID == id);
        }

        public List<MessUser> GetMUsersByMessage(Message message)
        {
            throw new NotImplementedException();
        }

        public int Add(MessUser muser)
        {
            context.MessUsers.Add(muser);
            return context.SaveChanges();
        }

        public int Edit(MessUser muser)
        {
            var userFromDb = GetMUserById(muser.MessUserID);
            userFromDb.Email = muser.Email;
            userFromDb.Username = muser.Username;
            userFromDb.MessUserID = muser.MessUserID;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var userFromDb = context.MessUsers.First(mu => mu.MessUserID == id);
            context.Remove(userFromDb);
            return context.SaveChanges();
        }
    }
}
