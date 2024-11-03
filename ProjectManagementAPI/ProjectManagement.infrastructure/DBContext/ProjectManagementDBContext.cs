using Microsoft.EntityFrameworkCore;
using ProjectManagement.Core.Entity;

namespace ProjectManagement.infrastructure.DBContext
{
    public class ProjectManagementDbContext : DbContext
    {
        public ProjectManagementDbContext(DbContextOptions<ProjectManagementDbContext> options)
            : base(options) { }

        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> Tasks { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<TaskDependency> TaskDependencies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskDependency>()
           .HasOne(td => td.Task)
           .WithMany(t => t.Dependencies)
           .HasForeignKey(td => td.TaskId)
           .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<TaskDependency>()
                .HasOne(td => td.DependentTask)
                .WithMany()
                .HasForeignKey(td => td.DependentTaskId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserRole>().HasData(
                new UserRole { Id = 1, RoleName = "Manager" },
                new UserRole { Id = 2, RoleName = "Employee" }
            );
        }
    }
}
