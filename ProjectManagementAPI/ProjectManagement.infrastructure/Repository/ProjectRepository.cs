using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entity;
using ProjectManagement.Core.Repository;
using ProjectManagement.infrastructure.DBContext;
using ProjectManagement.infrastructure.Repository;

public class ProjectRepository : RepositoryBase<Project>, IProjectRepository
{
    public ProjectRepository(ProjectManagementDbContext context) : base(context)
    {
    }
    public async Task<Project?> GetProjectIncludeTasksAsync(int id)
    {
        return await _dbSet
            .Include(p => p.Tasks)
            .FirstOrDefaultAsync(p => p.ProjectId == id);
    }
}