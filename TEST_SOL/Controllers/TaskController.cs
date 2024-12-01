
using Microsoft.AspNetCore.Mvc;
using TaskManagementAPI.Models;
using TaskManagementAPI.Services;

namespace TaskManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TasksController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public IActionResult GetAllTasks() => Ok(_taskService.GetAllTasks());

        [HttpGet("{id}")]
        public IActionResult GetTaskById(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null) return NotFound(new { Message = "Task not found" });
            return Ok(task);
        }

        [HttpPost]
        public IActionResult CreateTask(TaskItem task)
        {
            _taskService.CreateTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTask(int id, TaskItem task)
        {
            if (id != task.Id) return BadRequest(new { Message = "ID mismatch" });

            var existingTask = _taskService.GetTaskById(id);
            if (existingTask == null) return NotFound(new { Message = "Task not found" });

            _taskService.UpdateTask(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTask(int id)
        {
            var task = _taskService.GetTaskById(id);
            if (task == null) return NotFound(new { Message = "Task not found" });

            _taskService.DeleteTask(id);
            return NoContent();
        }

        [HttpGet("export")]
        public IActionResult ExportTasks()
        {
            var tasks = _taskService.GetAllTasks();
            var csv = "Id,Name,Description,Status\n" +
                      string.Join("\n", tasks.Select(t => $"{t.Id},{t.Name},{t.Description},{t.Status}"));
            return File(System.Text.Encoding.UTF8.GetBytes(csv), "text/csv", "tasks.csv");
        }
    }
}
