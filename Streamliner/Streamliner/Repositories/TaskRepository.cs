using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Streamliner.Models;

namespace Streamliner.Repositories
{
    // The repository object will be injected into a Controller by a transient service (configured in Startup)
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext context;

        public TaskRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        /* Interface method implementations */

        public List<TaskItem> GetAllTasks()
        {
            //return context.Tasks.Include(t => t.Kiddos).ToList();
            List<TaskItem> tasks = context.Tasks.ToList<TaskItem>();
            return tasks;
        }

        public TaskItem GetTaskById(int id)
        {
            return context.Tasks.Include("Kiddos").First(t => t.TaskItemID == id);
        }

        public List<TaskItem> GetTasksByKiddo(Kiddo kiddo)
        {
            //return (from t in context.Tasks
            //        where t.Kiddos.Contains(kiddo)
            //        select t).Include(t => t.Kiddos).ToList();
            throw new NotImplementedException();
        }

        //public int AddTask(TaskItem task)
        //{
        //    //Add the task to the database
        //    context.Tasks.Update(task);
        //    //Save the task so that it gets an ID(primary key value)
        //    context.SaveChanges();

        //Give each kiddo object an FK for the task and add it to the database
        //    foreach (Kiddo k in task.Kiddos)
        //        {
        //            k.TaskItemID = task.TaskItemID;
        //            context.Kiddos.Update(k);
        //        }

        //    return context.SaveChanges();
        //}

        public int AddTask(TaskItem task)
        {
            context.Tasks.Add(task);
            return context.SaveChanges();
        }

        public int Edit(TaskItem task)
        {
            context.Tasks.Update(task);
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var taskFromDb = context.Tasks.First(k => k.TaskItemID == id);
            context.Remove(taskFromDb);
            return context.SaveChanges();
        }
    }
}
