using AutoMapper;
using ProjectManagement.Application.DTO;
using ProjectManagement.Application.DTO.User;
using ProjectManagement.Application.DTO.Project;
using ProjectManagement.Core.Entity;
using ProjectManagement.Application.DTO.Task;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateUserDTO, User>();
        CreateMap<User, UserDTO>();

        CreateMap<CreateProjectDTO, Project>();
        CreateMap<UpdateProjectDTO, Project>();
        CreateMap<Project, CreateProjectDTO>();
        CreateMap<Project, UpdateProjectDTO>();

        CreateMap<CreateTaskDTO, ProjectTask>();
        CreateMap<UpdateTaskDTO, ProjectTask>();
        CreateMap<TaskDTO, ProjectTask>();
        CreateMap<ProjectTask, CreateTaskDTO>();
        CreateMap<ProjectTask, TaskListDTO>();
        CreateMap<ProjectTask, UpdateTaskDTO>();
        CreateMap<ProjectTask, TaskDTO>();

    }
}
