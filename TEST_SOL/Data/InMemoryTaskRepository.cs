//namespace TaskManagementAPI.Data
//{
//    public class InMemoryTaskRepository
//    {
//    }
//}

using System.Collections.Generic;
using System.Linq;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data
{
    public class InMemoryTaskRepository
    {
        private readonly List<TaskItem> _tasks = new();
        private int _idCounter = 1;

        // Retrieve all tasks
        public List<TaskItem> GetAll() => _tasks;

        // Retrieve a task by ID
        public TaskItem GetById(int id) => _tasks.FirstOrDefault(t => t.Id == id);

        // Add a new task
        public void Add(TaskItem task)
        {
            task.Id = _idCounter++;
            _tasks.Add(task);
        }

        // Update an existing task
        public void Update(TaskItem task)
        {
            var existingTask = GetById(task.Id);
            if (existingTask != null)
            {
                existingTask.Name = task.Name;
                existingTask.Description = task.Description;
                existingTask.Status = task.Status;
            }
        }

        // Delete a task by ID
        public void Delete(int id) => _tasks.RemoveAll(t => t.Id == id);
    }
}