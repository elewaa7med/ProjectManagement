using System.ComponentModel.DataAnnotations;

namespace ProjectManagement.Core.Entity
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public string Content { get; set; }
        public int TaskId { get; set; }
        public ProjectTask Task { get; set; }
    }
}
