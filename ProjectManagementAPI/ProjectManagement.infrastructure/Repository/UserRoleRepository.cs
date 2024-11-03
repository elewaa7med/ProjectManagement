using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entity;
using ProjectManagement.Core.Repository;
using ProjectManagement.infrastructure.DBContext;
using ProjectManagement.infrastructure.Repository;

public class UserRoleRepository : RepositoryBase<UserRole>,IUserRoleRepository
{
    public UserRoleRepository(ProjectManagementDbContext context) : base(context)
    {
       
    }
}