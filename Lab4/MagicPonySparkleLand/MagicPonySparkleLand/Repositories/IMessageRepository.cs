using MagicPonySparkleLand.Models;
using System.Linq;

namespace MagicPonySparkleLand.Repositories
{
    public interface IMessageRepository
    {
        IQueryable<Message> Messages { get; }
        IQueryable<User> Users { get; }
    }
}
