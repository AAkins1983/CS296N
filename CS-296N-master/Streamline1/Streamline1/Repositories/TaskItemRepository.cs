using Streamline1.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Streamline1.Repositories
{
    public class TaskItemRepository : ITaskItemRepository
    {
        private ApplicationDbContext context;

        public TaskItemRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public List<TaskItem> GetAllTasks()
        {
            List<TaskItem> taskItems = context.TaskItems.ToList<TaskItem>();
            return taskItems;
        }

        public TaskItem GetTaskByDescription(string description)
        {
            throw new NotImplementedException();
        }

        public TaskItem GetTaskByCategory(string category)
        {
            throw new NotImplementedException();
        }

        public List<TaskItem> GetTaskByKiddo(Kiddo kiddo)
        {
            throw new NotImplementedException();
        }

        public TaskItem GetTaskById(int id)
        {
            return context.TaskItems.First(t => t.TaskItemID == id);
        }

        public int Add(TaskItem taskItem)
        {
            context.TaskItems.Add(taskItem);
            return context.SaveChanges();
        }

        //public int Add(TaskItem taskItem)
        //{
        //    // Add the book to the database
        //    context.TaskItems.Update(taskItem);
        //    // Save the book so that it gets an ID (primary key value)
        //    context.SaveChanges();

        //    // Give each kiddo object an FK for the task
        //    // and add it to the database
        //    //foreach (Kiddo k in taskItem.Kiddos)
        //    //{
        //    //    k.TaskItemID = task.TaskItemID;
        //    //    context.Kiddos.Update(k);
        //    //}

        //    return context.SaveChanges();
        //}

        public int Edit(TaskItem taskItem)
        {
            var taskFromDb = GetTaskById(taskItem.TaskItemID);
            taskFromDb.Description = taskItem.Description;
            taskFromDb.Category = taskItem.Category;
            taskFromDb.TaskItemID = taskItem.TaskItemID;
            return context.SaveChanges();
        }

        public int Delete(int id)
        {
            var taskFromDb = context.TaskItems.First(t => t.TaskItemID == id);
            context.Remove(taskFromDb);
            return context.SaveChanges();
        }
    }
}

