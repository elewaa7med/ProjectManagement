
using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Core.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public int RoleId { get; set; }
        public UserRole Role { get; set; }
    }
}
