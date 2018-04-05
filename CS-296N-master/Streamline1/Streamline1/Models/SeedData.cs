using Microsoft.Extensions.DependencyInjection;
using Streamline1.Models;
using System;
using System.Linq;

namespace Streamline1
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider services)
        {
            ApplicationDbContext context = services.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Kiddos.Any())
            {
                Kiddo kiddo = new Kiddo { Name = "Kid #1" };
                context.Kiddos.Add(kiddo);    // add the kid to the dB Context
                context.SaveChanges();      // save it so it gets an ID (PK value)
                TaskItem taskItem = new TaskItem { Description = "Task #1", Category = "Morning", KiddoID = kiddo.KiddoID };
                context.TaskItems.Add(taskItem);
                kiddo.TaskItems.Add(taskItem);

                kiddo = new Kiddo { Name = "Kid #2" };
                context.Kiddos.Add(kiddo);
                context.SaveChanges();
                taskItem = new TaskItem { Description = "Task #2", Category = "After School", KiddoID = kiddo.KiddoID };
                context.TaskItems.Add(taskItem);
                kiddo.TaskItems.Add(taskItem);

                kiddo = new Kiddo { Name = "Kid #3" };
                context.Kiddos.Add(kiddo);
                context.SaveChanges();
                taskItem = new TaskItem { Description = "Task #3", Category = "Bedtime", KiddoID = kiddo.KiddoID };
                context.TaskItems.Add(taskItem);
                kiddo.TaskItems.Add(taskItem);

                context.SaveChanges(); // save the last addition
            }
        }
    }
}
