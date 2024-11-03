using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entity;
using ProjectManagement.Core.Repository;
using ProjectManagement.infrastructure.DBContext;
using ProjectManagement.infrastructure.Repository;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(ProjectManagementDbContext context) : base(context)
    {
    }

    public async Task<User?> GetUserByUsername(string username)
    {
        return await _dbSet
            .Include(u => u.Role)
            .SingleOrDefaultAsync(u => u.Username == username);
    }

    public async Task<IEnumerable<User?>> GetEmployees()
    {
        return await _dbSet
            .Where(u=> u.Role.RoleName == "Employee")
            .Include(u => u.Role)
            .ToListAsync();
    }
}