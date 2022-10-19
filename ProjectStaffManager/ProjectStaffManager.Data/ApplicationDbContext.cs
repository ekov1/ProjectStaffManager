using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ProjectStaffManager.Models.Entities;

namespace ProjectStaffManager.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<StaffMember> StaffMembers { get; set; }
        public DbSet<ProjectStaffMember> ProjectStaffMembers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder.Entity<ProjectStaffMember>()
            //   .HasKey(x => new { x.StaffMemberID, x.ProjectID });

           
            base.OnModelCreating(modelBuilder);
        }
    }
}
