using AutoMapper;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.Project;
using ProjectManagement.Application.DTO.Task;
using ProjectManagement.Application.Exceptions;
using ProjectManagement.Core.Entity;
using ProjectManagement.Core.Repository;
using System.Threading.Tasks;

namespace ProjectManagement.Application.Service.TaskService
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IProjectRepository ProjectRepository, IUserRepository userRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _projectRepository = ProjectRepository;
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<TaskListDTO>> GetTasksAsync(PaginationDTO pagination) => _mapper.Map<List<TaskListDTO>>(await _taskRepository.GetAllAsync(pagination.page, pagination.pageSize));
        public async Task<TaskDTO> GetTaskIncludeAllAsync(int id) => _mapper.Map<TaskDTO>(await _taskRepository.GetTaskIncludeAllAsync(id)) ?? throw new NotFoundException("Task Not Found");

        public async Task<TaskDTO> CreateTaskAsync(CreateTaskDTO taskDTO)
        {
            var ExistingProject = await _projectRepository.GetByIdAsync(taskDTO.ProjectId) ?? throw new NotFoundException("Project Not Found");
            var ExistingUser = taskDTO.AssignedToUserId != null ? await _userRepository.GetByIdAsync((int)taskDTO.AssignedToUserId) ?? throw new NotFoundException("User Not Found") : null;
            var task = _mapper.Map<ProjectTask>(taskDTO);
            await _taskRepository.AddAsync(task);
            return _mapper.Map<TaskDTO>(task);
        }
        public async Task<TaskDTO> UpdateTaskAsync(int id, UpdateTaskDTO taskDTO, string RoleName)
        {
            var ExistingTask = await _taskRepository.GetByIdAsync(id) ?? throw new NotFoundException("Task Not Found");
            if(RoleName == "Manager")
            {
                var ExistingUser = taskDTO.AssignedToUserId != null ? await _userRepository.GetByIdAsync((int)taskDTO.AssignedToUserId) ?? throw new NotFoundException("User Not Found") : null;
                _mapper.Map<UpdateTaskDTO, ProjectTask>(taskDTO, ExistingTask);
            }
            ExistingTask.Status = taskDTO.Status;
            await _taskRepository.UpdateAsync(ExistingTask);
            return _mapper.Map<TaskDTO>(ExistingTask);
        }
        
        public async Task DeleteTaskAsync(int id)
        {
            var ExistingTask = await _taskRepository.GetByIdAsync(id) ?? throw new NotFoundException("Task Not Found");
            await _taskRepository.DeleteAsync(ExistingTask);
        }


        public async Task<IEnumerable<TaskListDTO>> GetOverdueTasksAsync() => _mapper.Map<List<TaskListDTO>>(await _taskRepository.GetOverdueTasksAsync());
        
    }
}
