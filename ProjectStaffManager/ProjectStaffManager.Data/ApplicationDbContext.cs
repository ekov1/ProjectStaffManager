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

            modelBuilder.Entity<ProjectStaffMember>()
                .HasKey(psm => new { psm.ProjectId, psm.StaffMemberId });

            modelBuilder.Entity<ProjectStaffMember>()
                .HasOne(psm => psm.Project)
                .WithMany(p => p.ProjectStaffMembers)
                .HasForeignKey(fk => fk.ProjectId);

            modelBuilder.Entity<ProjectStaffMember>()
                .HasOne(psm => psm.StaffMember)
                .WithMany(sm => sm.ProjectStaffMembers)
                .HasForeignKey(fk => fk.StaffMemberId);


            base.OnModelCreating(modelBuilder);
        }
    }
}
