using ProjectManagement.Core.Enum;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
namespace ProjectManagement.Core.Entity
{
    public class ProjectTask
    {
        [Key]
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; } = Status.NotStarted;
        
        public string? AssignedToName { get; set; }
        public int? AssignedToUserId { get; set; }
        public User? AssignedToUser { get; set; }

        public int ProjectId { get; set; }
        [JsonIgnore]
        public Project Project { get; set; }

        public List<Comment> Comments { get; set; }
        public List<TaskDependency> Dependencies { get; set; }
    }
}
