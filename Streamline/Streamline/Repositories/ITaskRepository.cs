using Streamline.Models;
using System.Collections.Generic;

namespace Streamline.Repositories
{
    public interface ITaskRepository
    {
        List<TaskItem> GetTasksByKiddo(Kiddo kiddo);
        List<TaskItem> GetAllTasks();
        TaskItem GetTaskByDescription(string description);
    }
}
