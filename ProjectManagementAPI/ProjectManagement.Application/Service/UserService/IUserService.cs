using ProjectManagement.Application.DTO.User;
using ProjectManagement.Core.Entity;

namespace ProjectManagement.Application.Service.UserService
{
    public interface IUserService
    {
        Task<List<UserDTO>> GetEmployees();
        Task<UserDTO> Register(CreateUserDTO user);
        Task<string> Login(LoginUserDTO login);
    }
}
