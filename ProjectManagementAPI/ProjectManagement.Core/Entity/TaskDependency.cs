using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Core.Entity
{
    public class TaskDependency
    {
        [Key]
        public int TaskDependencyId { get; set; }
        public int TaskId { get; set; }
        public ProjectTask Task { get; set; }

        public int DependentTaskId { get; set; }
        public ProjectTask DependentTask { get; set; }
    }
}
