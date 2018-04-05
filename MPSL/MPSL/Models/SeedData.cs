using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MPSL.Models;
using System;
using System.Linq;

namespace MPSL
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Messages.Any())
            {
                Message message = new Message { MessageText = "Here is a message.", Date = DateTime.Parse("1/1/1901") }; // month/day/year
                context.Messages.Add(message);    // add the message to the dB Context
                context.SaveChanges();      // save it so it gets an ID (PK value)
                MessUser muser = new MessUser { Email = "elmo@sesame.street", Username = "RedNFuzzy", MessageID = message.MessageID };
                context.MessUsers.Add(muser);
                message.MessUsers.Add(muser);

                message = new Message { MessageText = "Here is another message.", Date = DateTime.Parse("1/1/2001") };
                context.Messages.Add(message);
                context.SaveChanges();
                muser = new MessUser { Email = "oprah@harpo.com", Username = "Oprah", MessageID = message.MessageID };
                context.MessUsers.Add(muser);
                message.MessUsers.Add(muser);

                message = new Message { MessageText = "And another.", Date = DateTime.Parse("1/1/3001") };
                context.Messages.Add(message);
                context.SaveChanges();
                muser = new MessUser { Email = "flava@flav.com", Username = "TheFlav", MessageID = message.MessageID };
                context.MessUsers.Add(muser);
                message.MessUsers.Add(muser);

                context.SaveChanges(); // save the last addition
            }
        }
    }
}
