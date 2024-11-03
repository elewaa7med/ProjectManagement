using ProjectManagement.Core.Enum;
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Core.Entity
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal Budget { get; set; }
        public string? Owner { get; set; }
        public Status Status { get; set; } = Status.NotStarted;

        public List<ProjectTask>? Tasks { get; set; }
    }
}
