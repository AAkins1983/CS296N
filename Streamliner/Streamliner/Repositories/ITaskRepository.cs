using Streamliner.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Streamliner.Repositories
{
    public interface ITaskRepository
    {
        List<TaskItem> GetAllTasks();
        TaskItem GetTaskById(int id);
        List<TaskItem> GetTasksByKiddo(Kiddo kiddo);
        int AddTask(TaskItem task);
        int Edit(TaskItem task);
        int Delete(int id);
    }
}
