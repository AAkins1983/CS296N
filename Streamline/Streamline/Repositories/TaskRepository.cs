using Streamline.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Streamline.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        public List<TaskItem> GetAllTasks()
        {
            // Temporary development implementation
            var tasks = new List<TaskItem>();
            tasks.Add(new TaskItem() { Description = "Task #1", Category = "Morning" });
            tasks.Add(new TaskItem() { Description = "Task #2", Category = "After School" });
            return tasks;
        }

        public TaskItem GetTaskByDescription(string description)
        {
            throw new NotImplementedException();
        }

        public List<TaskItem> GetTasksByKiddo(Kiddo kiddo)
        {
            throw new NotImplementedException();
        }
    }
}
