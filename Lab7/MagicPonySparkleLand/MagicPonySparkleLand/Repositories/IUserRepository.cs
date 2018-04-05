using MagicPonySparkleLand.Models;
using System.Collections.Generic;

namespace MagicPonySparkleLand.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();
        User GetUserByName(string name);
        User GetUserById(int id);
        int Add(User user);
        int Edit(User user);
        int Delete(int id);
    }
}
