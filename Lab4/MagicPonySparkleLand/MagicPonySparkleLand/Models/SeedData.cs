using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;

namespace MagicPonySparkleLand.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
            .GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Messages.Any())
            {
                context.Messages.AddRange(
                new Message
                {
                    Date = DateTime.Parse("01/01/2001"),
                    Name = "Gidget",
                    Email = "Gidget@email.com",
                    MessageText = "Message #1!",
                },

                new Message
                {
                    Date = DateTime.Parse("05/05/2005"),
                    Name = "Elmo",
                    Email = "Elmo@sesame.street",
                    MessageText = "Message #2!",
                },

                new Message
                {
                    Date = DateTime.Parse("02/04/2018"),
                    Name = "Manda",
                    Email = "Manda@gmail.com",
                    MessageText = "Here is my message!",
                },

                new Message
                {
                    Date = DateTime.Parse("10/10/2010"),
                    Name = "Talula",
                    Email = "Talula@yahoo.com",
                    MessageText = "Message #3!",
                });
                context.SaveChanges();
            }
        }
    }
}
