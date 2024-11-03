using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.Project;
using ProjectManagement.Application.DTO.User;
using ProjectManagement.Core.Entity;

namespace ProjectManagement.Application.Service.ProjectService
{
    public interface IProjectService
    {
        Task<IEnumerable<Project>> GetProjectsAsync(PaginationDTO pagination);
        Task<Project> GetProjectIncludeTasksAsync(int id);
        Task<Project> CreateProjectAsync(CreateProjectDTO project);
        Task<Project> UpdateProjectAsync(int id,UpdateProjectDTO project);
        Task DeleteProjectAsync(int id);
    }
}
