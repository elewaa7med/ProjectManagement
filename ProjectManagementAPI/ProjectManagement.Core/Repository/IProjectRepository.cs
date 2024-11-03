using ProjectManagement.Core.Entity;


namespace ProjectManagement.Core.Repository
{
    public interface IProjectRepository : IRepository<Project>
    {
        Task<Project?> GetProjectIncludeTasksAsync(int id);
    }

   
}
