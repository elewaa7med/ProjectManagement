using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using ProjectManagement.Application.DTO.User;
using ProjectManagement.Application.Response;
using ProjectManagement.Application.Service.UserService;
using ProjectManagement.Core.Entity;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] CreateUserDTO user)
        {
            var createdUser = await _userService.Register(user);
            return CreatedAtAction(nameof(Register), new Response<UserDTO>(createdUser));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginUserDTO login)
        {
            var token = await _userService.Login(login);
            return Ok(new Response<string>(token));
        }

        [HttpPost("Employees")]
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> GetEmployees()
        {
            var Employees = await _userService.GetEmployees();
            return Ok(new Response<List<UserDTO>>(Employees));
        }
    }
}
