using ProjectManagement.Core.Entity;
using ProjectManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.Task
{
    public class TaskListDTO
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Priority Priority { get; set; } = Priority.High;
        public Status Status { get; set; } = Status.NotStarted;
        public string AssignedToName { get; set; }
        public int? AssignedToUserId { get; set; }
        public int ProjectId { get; set; }
    }
}
