using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.Project;
using ProjectManagement.Application.Response;
using ProjectManagement.Application.Service.ProjectService;
using ProjectManagement.Core.Entity;

namespace ProjectManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }


        [HttpGet]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> GetProjects([FromQuery] PaginationDTO pagination)
        {
            var projects = await _projectService.GetProjectsAsync(pagination);
            return Ok(new Response<IEnumerable<Project>>(projects));
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> GetProject(int id)
        {
            var project = await _projectService.GetProjectIncludeTasksAsync(id);
            return Ok(new Response<Project>(project));
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> CreateProject(CreateProjectDTO project)
        {
            var createdProject = await _projectService.CreateProjectAsync(project);
            return CreatedAtAction(nameof(CreateProject), new Response<Project>(createdProject));
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Manager,Employee")]
        public async Task<IActionResult> UpdateProject(int id, [FromBody] UpdateProjectDTO project)
        {
            var updatedProject = await _projectService.UpdateProjectAsync(id, project);
            return Ok(new Response<Project>(updatedProject));
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> DeleteProject(int id)
        {
            await _projectService.DeleteProjectAsync(id);
            return Ok();
        }
    }
}
