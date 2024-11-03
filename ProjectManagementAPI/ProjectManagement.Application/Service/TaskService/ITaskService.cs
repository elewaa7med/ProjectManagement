using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.Project;
using ProjectManagement.Application.DTO.Task;
using ProjectManagement.Application.DTO.User;
using ProjectManagement.Core.Entity;

namespace ProjectManagement.Application.Service.TaskService
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskListDTO>> GetTasksAsync(PaginationDTO pagination);
        Task<TaskDTO> GetTaskIncludeAllAsync(int id);
        Task<TaskDTO> CreateTaskAsync(CreateTaskDTO task);
        Task<TaskDTO> UpdateTaskAsync(int id, UpdateTaskDTO task, string RoleName);
        Task DeleteTaskAsync(int id);
        Task<IEnumerable<TaskListDTO>> GetOverdueTasksAsync();
    }
}
