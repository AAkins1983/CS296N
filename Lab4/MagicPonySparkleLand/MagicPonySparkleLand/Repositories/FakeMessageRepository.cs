using MagicPonySparkleLand.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MagicPonySparkleLand.Repositories
{
    public class FakeMessageRepository : IMessageRepository
    {
        public IQueryable<Message> Messages => new List<Message>
        {
            new Message {MessageText = "Message #1!", Date = DateTime.Parse("01/01/2001") },
            new Message {MessageText = "Message #2!", Date = DateTime.Parse("05/05/2005") },
            new Message {MessageText = "Message #3!", Date = DateTime.Parse("10/10/2010") },
        }.AsQueryable<Message>();

        public IQueryable<User> Users => new List<User>
        {
            new User {Name = "Gidget", Email = "Gidget@email.com" },
            new User {Name = "Elmo", Email = "Elmo@sesame.street" },
            new User {Name = "Talula", Email = "Talula@yahoo.com" },
        }.AsQueryable<User>();
    }
} 
