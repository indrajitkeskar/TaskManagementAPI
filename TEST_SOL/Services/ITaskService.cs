

using System.Collections.Generic;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public interface ITaskService
    {
        List<TaskItem> GetAllTasks();
        TaskItem GetTaskById(int id);
        void CreateTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(int id);
    }
}
