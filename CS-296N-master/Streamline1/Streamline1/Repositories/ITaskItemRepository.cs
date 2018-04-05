using Streamline1.Models;
using System.Collections.Generic;

namespace Streamline1.Repositories
{
    public interface ITaskItemRepository
    {
        List<TaskItem> GetTaskByKiddo(Kiddo kiddo);
        List<TaskItem> GetAllTasks();
        TaskItem GetTaskByDescription(string description);
        TaskItem GetTaskByCategory(string description);
        TaskItem GetTaskById(int id);
        int Add(TaskItem taskItem);
        int Edit(TaskItem taskItem);
        int Delete(int id);
    }
}
