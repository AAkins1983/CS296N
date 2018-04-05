using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Streamline.Models;
using System.Linq;

namespace Streamline
{
    public class SeedData
    {
        public static void PopulateDb(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.EnsureCreated();
            if (!context.Tasks.Any())
            {
                TaskItem task = new TaskItem { Description = "Task #1", Category = "Morning" };
                context.Tasks.Add(task);    // add the task to the dB Context
                context.SaveChanges();      // save it so it gets an ID (PK value)
                Kiddo kiddo = new Kiddo { Name = "Kid #1", TaskItemID = task.TaskItemID };
                context.Kiddos.Add(kiddo);
                kiddo.Tasks.Add(task);

                task = new TaskItem { Description = "Task #2", Category = "After School" };
                context.Tasks.Add(task);
                context.SaveChanges();
                kiddo = new Kiddo { Name = "Kid #2", TaskItemID = task.TaskItemID };
                context.Kiddos.Add(kiddo);
                kiddo.Tasks.Add(task);

                task = new TaskItem { Description = "Task #3", Category = "Bedtime" };
                context.Tasks.Add(task);
                context.SaveChanges();
                kiddo = new Kiddo { Name = "Kid #3", TaskItemID = task.TaskItemID };
                context.Kiddos.Add(kiddo);
                kiddo.Tasks.Add(task);

                context.SaveChanges(); // save the last addition
            }
        }
    }

}
