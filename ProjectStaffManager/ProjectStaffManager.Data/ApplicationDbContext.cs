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
               .HasKey(x => new { x.StaffMemberID, x.ProjectID });

            // First define the new key
            //builder.HasKey(p => new { p.BusinessDay, p.ClientId, p.Version });

            // Then configure the auto generated column
            // This (especially the `SetAfterUpdateBehavior` call) must be after 
            // unassociating the property as a PK, otherwise you'll get an exception
            modelBuilder.Entity<ProjectStaffMember>().Property(p => p.Id)
                .ValueGeneratedOnAdd()
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<StaffMember>().Property(p => p.Id)
              .ValueGeneratedOnAdd()
              .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

            modelBuilder.Entity<Project>().Property(p => p.Id)
              .ValueGeneratedOnAdd()
              .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            // <--

            //modelBuilder.Entity<ProjectStaffMember>()
            //    .HasOne<StaffMember>(psm => psm.StaffMember)
            //    .WithMany(sm => sm.ProjectStaffMembers)
            //    .HasForeignKey(pms => pms.StaffMemberId);


            //modelBuilder.Entity<ProjectStaffMember>()
            //    .HasOne<Project>(psm => psm.Project)
            //    .WithMany(p => p.ProjectStaffMembers)
            //    .HasForeignKey(pms => pms.ProjectId);

            //ProjectStafMember projectStafMember = new ProjectStafMember()
            //{
            //    Id = 5,
            //    Project = new Project() { Id = 5, CreatedOn = DateTime.Now },
            //    StaffMember = new StaffMember() { Id = 6, CreatedOn = DateTime.Now },
            //    DateFrom = new DateTime(2020, 6, 22)
            //};

            //modelBuilder.Entity<ProjectStafMember>().HasData(projectStafMember);
            //base.OnModelCreating(modelBuilder);
        }
    }
}
