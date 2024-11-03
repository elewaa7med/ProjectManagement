using ProjectManagement.Core.Entity;


namespace ProjectManagement.Core.Repository
{
    public interface ITaskRepository : IRepository<ProjectTask>
    {
        Task<IEnumerable<ProjectTask>> GetOverdueTasksAsync();
        Task<ProjectTask?> GetTaskIncludeAllAsync(int id);

    }
}
