using AutoMapper;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.Project;
using ProjectManagement.Application.Exceptions;
using ProjectManagement.Core.Entity;
using ProjectManagement.Core.Repository;

namespace ProjectManagement.Application.Service.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IMapper _mapper;

        public ProjectService(IProjectRepository projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Project>> GetProjectsAsync(PaginationDTO pagination) => await _projectRepository.GetAllAsync(pagination.page, pagination.pageSize);

        public async Task<Project> GetProjectIncludeTasksAsync(int id) => await _projectRepository.GetProjectIncludeTasksAsync(id) ?? throw new NotFoundException("Project Not Found");

        public async Task<Project> CreateProjectAsync(CreateProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            await _projectRepository.AddAsync(project);
            return project;
        }

        public async Task<Project> UpdateProjectAsync(int id, UpdateProjectDTO updatedProject)
        {
            var ExistingProject = await _projectRepository.GetByIdAsync(id) ?? throw new NotFoundException("Project Not Found");
            _mapper.Map<UpdateProjectDTO, Project>(updatedProject, ExistingProject);
            await _projectRepository.UpdateAsync(ExistingProject);
            return ExistingProject;
        }
        public async Task DeleteProjectAsync(int id)
        {
            var Project = await _projectRepository.GetByIdAsync(id) ?? throw new NotFoundException("Project Not Found");
            await _projectRepository.DeleteAsync(Project);
        }
       
    }
}
