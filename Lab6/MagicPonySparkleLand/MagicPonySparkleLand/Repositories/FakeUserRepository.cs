using MagicPonySparkleLand.Models;
using System;
using System.Collections.Generic;

namespace MagicPonySparkleLand.Repositories
{
    public class FakeUserRepository : IUserRepository
    {
        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            users.Add(new User() { Name = "Gidget", Email = "Gidget@email.com" });
            users.Add(new User() { Name = "Elmo", Email = "sesame@street.com" });

            return users;
        }

        public User GetUserByName(string name)
        {
            throw new NotImplementedException();
        }

        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public int Edit(User user)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public int Add(User user)
        {
            throw new NotImplementedException();
        }
    }
}
