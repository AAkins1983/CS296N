using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using System;
using MagicPonySparkleLand.Models;

namespace MagicPonySparkleLand
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            //ApplicationDbContext context = app.ApplicationServices
            //.GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Messages.Any())
            {
                Message message = new Message { MessageText = "Message #1!", Date = DateTime.Parse("01/01/2001") }; // month/day/year
                context.Messages.Add(message); //Add message to the Db Context
                context.SaveChanges(); //Save it so it gets an ID (PK value)
                User user = new User { Name = "Gidget", Email = "Gidget@yahoo.com", MessageID = message.MessageID };
                context.Users.Add(user);
                message.Users.Add(user);

                message = new Message { MessageText = "Message #2!", Date = DateTime.Parse("05/05/2005") };
                context.Messages.Add(message);
                context.SaveChanges();
                user = new User { Name = "Elmo", Email = "Sesame@street.com", MessageID = message.MessageID };
                context.Users.Add(user);
                message.Users.Add(user);

                message = new Message { MessageText = "Message #3!", Date = DateTime.Parse("10/10/2010") };
                context.Messages.Add(message);
                context.SaveChanges();
                user = new User { Name = "Talula", Email = "email@email.com", MessageID = message.MessageID };
                context.Users.Add(user);
                message.Users.Add(user);

                context.SaveChanges(); //Save the last addition
            }

            //ApplicationDbContext context = app.ApplicationServices
            //.GetRequiredService<ApplicationDbContext>();
            //context.Database.Migrate();
            //if (!context.Messages.Any())
            //{
            //    context.Messages.AddRange(
            //    new Message
            //    {
            //        Date = DateTime.Parse("01/01/2001"),
            //        Name = "Gidget",
            //        Email = "Gidget@email.com",
            //        MessageText = "Message #1!",
            //    },

            //    new Message
            //    {
            //        Date = DateTime.Parse("05/05/2005"),
            //        Name = "Elmo",
            //        Email = "Elmo@sesame.street",
            //        MessageText = "Message #2!",
            //    },

            //    new Message
            //    {
            //        Date = DateTime.Parse("02/04/2018"),
            //        Name = "Manda",
            //        Email = "Manda@gmail.com",
            //        MessageText = "Here is my message!",
            //    },

            //    new Message
            //    {
            //        Date = DateTime.Parse("10/10/2010"),
            //        Name = "Talula",
            //        Email = "Talula@yahoo.com",
            //        MessageText = "Message #3!",
            //    });
            //    context.SaveChanges();
            //}
        }
    }
}
