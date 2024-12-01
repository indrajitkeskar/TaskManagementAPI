//namespace TaskManagementAPI.Services
//{
//    public class TaskService
//    {
//    }
//}

using System.Collections.Generic;
using TaskManagementAPI.Data;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly InMemoryTaskRepository _repository;

        public TaskService(InMemoryTaskRepository repository)
        {
            _repository = repository;
        }

        public List<TaskItem> GetAllTasks() => _repository.GetAll();

        public TaskItem GetTaskById(int id) => _repository.GetById(id);

        public void CreateTask(TaskItem task) => _repository.Add(task);

        public void UpdateTask(TaskItem task) => _repository.Update(task);

        public void DeleteTask(int id) => _repository.Delete(id);
    }
}