using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ProjectManagement.Application.DTO.User;
using ProjectManagement.Application.Exceptions;
using ProjectManagement.Core.Entity;
using ProjectManagement.Core.Repository;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectManagement.Application.Service.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IMapper _mapper;

        public UserService(IPasswordHasher<User> passwordHasher, IConfiguration configuration, IUserRepository userRepository, IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _userRoleRepository = userRoleRepository;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
            _mapper = mapper;
        }

        public async Task<UserDTO> Register(CreateUserDTO createUser)
        {
            var user = _mapper.Map<User>(createUser);
            user.HashedPassword = _passwordHasher.HashPassword(user, createUser.Password);
            var existingUser = await _userRepository.GetUserByUsername(user.Username);
            if (existingUser != null)
            {
                throw new AlreadyExistsException("Username already exists.");
            }
            var existingRole = await _userRoleRepository.GetByIdAsync(user.RoleId) ?? throw new ArgumentException("Invalid role ID.");
            return _mapper.Map<UserDTO>(await _userRepository.AddAsync(user));
        }

        public async Task<string> Login(LoginUserDTO login)
        {
            var user = await _userRepository.GetUserByUsername(login.Username) ??
                throw new UnauthorizedAccessException("Invalid username or password.");
            var result = _passwordHasher.VerifyHashedPassword(user, user.HashedPassword, login.Password);
            return result == PasswordVerificationResult.Success ?
                GenerateJwtToken(user) :
                throw new UnauthorizedAccessException("Invalid username or password.");
        }
        public async Task<List<UserDTO>> GetEmployees()
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.GetEmployees());
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Username),
                new Claim("role", user.Role.RoleName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
