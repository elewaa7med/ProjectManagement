using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Core.Entity
{
    public class UserRole
    {
        [Key]
        public int Id { get; set; }
        public string RoleName { get; set; } // e.g., "Manager", "Employee"
    }
}
