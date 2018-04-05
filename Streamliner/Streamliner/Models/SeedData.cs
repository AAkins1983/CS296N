using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Microsoft.AspNetCore.Builder;

namespace Streamliner.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            context.Database.Migrate();
            if (!context.Kiddos.Any())
            {
                Kiddo kiddo = new Kiddo { Name = "Kid #1" }; 
                kiddo.TaskItems.Add(new Kiddo { Name = "Kid #1" });
                context.Tasks.Add(kiddo);

                task = new Book { Title = "The Lion, the Witch, and the Wardrobe", Date = DateTime.Parse("1/1/1950") };
                task.Authors.Add(new Author { Name = "C. S. Lewis" });
                context.Books.Add(task);

                task = new Book { Title = "Prince of Foxes", Date = DateTime.Parse("1/1/1947") };
                task.Authors.Add(new Author { Name = "Samuel Shellabarger" });
                context.Books.Add(task);
                context.SaveChanges();
                //if (!context.Tasks.Any())
                //{
                //    context.Tasks.AddRange(
                //        new TaskItem
                //        {
                //            Description = "Get Dressed",
                //            Category = "Morning"
                //        },
                //        new TaskItem
                //        {
                //            Description = "Eat Breakfast",
                //            Category = "Morning"
                //        },
                //        new TaskItem
                //        {
                //            Description = "Brush Teeth",
                //            Category = "Morning"
                //        },
                //        new TaskItem
                //        {
                //            Description = "Brush Hair",
                //            Category = "Morning",
                //        },
                //        new TaskItem
                //        {
                //            Description = "Get Backpacks and Coats",
                //            Category = "Morning"
                //        },
                //        new TaskItem
                //        {
                //            Description = "Put BackPacks and Coats Away",
                //            Category = "After School",
                //        },
                //        new TaskItem
                //        {
                //            Description = "Eat Snack",
                //            Category = "After School"
                //        },
                //        new TaskItem
                //        {
                //            Description = "Bathtime",
                //            Category = "Bedtime"
                //        },
                //        new TaskItem
                //        {
                //            Description = "Brush Teeth",
                //            Category = "Bedtime"
                //        },
                //        new TaskItem
                //        {
                //            Description = "Pick out Outfits",
                //            Category = "Bedtime"
                //        },
                //        new TaskItem
                //        {
                //            Description = "Read",
                //            Category = "Bedtime"
                //        }
                //    );
                //    context.SaveChanges();
            }
        }
    }
}
