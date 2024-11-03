using ProjectManagement.Core.Entity;
using ProjectManagement.Core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Application.DTO.Task
{
    public class CreateTaskDTO
    {
        [Required]
        public string TaskName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Priority Priority { get; set; }
        public Status Status { get; set; } = Status.NotStarted;
        public int? AssignedToUserId { get; set; }
        [Required]
        public int ProjectId { get; set; }

    }
}
