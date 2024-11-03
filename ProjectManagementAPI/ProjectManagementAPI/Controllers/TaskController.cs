using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.Task;
using ProjectManagement.Application.Response;
using ProjectManagement.Application.Service.TaskService;
using System.Security.Claims;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : Controller
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> GetTasks([FromQuery] PaginationDTO pagination)
        {
            var tasks = await _taskService.GetTasksAsync(pagination);
            return Ok(new Response<IEnumerable<TaskListDTO>>(tasks));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> GetTask(int id)
        {
            var task = await _taskService.GetTaskIncludeAllAsync(id);
            return Ok(new Response<TaskDTO>(task));
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateTask(CreateTaskDTO task)
        {
            var createdTask = await _taskService.CreateTaskAsync(task);
            return CreatedAtAction(nameof(CreateTask), new Response<TaskDTO>(createdTask));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> UpdateTask(int id, UpdateTaskDTO task)
        {
            var updatedTask = await _taskService.UpdateTaskAsync(id, task,ClaimTypes.Role);
            return Ok(new Response<TaskDTO>(updatedTask));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            await _taskService.DeleteTaskAsync(id);
            return Ok();
        }

        [HttpGet("overdue")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> GetOverdueTasks()
        {
            var overdueTasks = await _taskService.GetOverdueTasksAsync();
            return Ok(new Response<IEnumerable<TaskListDTO>>(overdueTasks));
        }
    }
}
