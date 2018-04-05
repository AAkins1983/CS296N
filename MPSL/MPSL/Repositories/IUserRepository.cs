using MPSL.Models;
using System.Collections.Generic;

namespace MPSL.Repositories
{
    public interface IUserRepository
    {
        List<MessUser> GetMUsersByMessage(Message message);
        List<MessUser> GetAllMUsers();
        MessUser GetMUserByName(string name);
        MessUser GetMUserById(int id);
        int Add(MessUser user);
        int Edit(MessUser user);
        int Delete(int id);
    }
}
