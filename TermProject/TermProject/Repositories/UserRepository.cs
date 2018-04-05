using MagicPonySparkleLand.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicPonySparkleLand.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ApplicationDbContext context;

        public UserRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = context.Users.ToList<User>();
            return users;
        }

        public User GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            return context.Users.First(u => u.UserID == id);
        }

        public int Add(User user)
        {
            context.Users.Add(user);
            return context.SaveChanges();
        }

        public int Edit(User user)
        {
            var userFromDb = GetUserById(user.UserID);
            userFromDb.Name = user.Name;
            userFromDb.Email = user.Email;
            userFromDb.MessageID = user.MessageID;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var userFromDb = context.Users.First(u => u.UserID == id);
            context.Remove(userFromDb);
            return context.SaveChanges();
        }
    }
}
