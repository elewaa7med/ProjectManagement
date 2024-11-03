using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entity;
using ProjectManagement.Core.Repository;
using ProjectManagement.infrastructure.DBContext;
using ProjectManagement.infrastructure.Repository;
using ProjectManagement.Core.Enum;

public class TaskRepository : RepositoryBase<ProjectTask>, ITaskRepository
{
    public TaskRepository(ProjectManagementDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ProjectTask>> GetOverdueTasksAsync()
    {
        return await _dbSet
            .Where(t => t.EndDate < DateTime.Now && t.Status != Status.Completed)
            .ToListAsync();
    }


    public async Task<ProjectTask?> GetTaskIncludeAllAsync(int id)
    {
        return await _dbSet
          .Include(p => p.Comments)
          .Include(p => p.AssignedToUser)
          .Include(p => p.Dependencies)
          .FirstOrDefaultAsync(p => p.TaskId == id);
    }
}