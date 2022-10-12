using Microsoft.EntityFrameworkCore;
using ProjectStaffManager.Data;
using ProjectStaffManager.Models.Entities;
using ProjectStaffManager.Models.ViewModels;
using ProjectStaffManager.Services.Interfaces;

namespace ProjectStaffManager.Services
{
    public class ProjectStaffMemberService : IProjectStaffMemberService
    {
        private ApplicationDbContext context;

        public ProjectStaffMemberService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public bool Create(IEnumerable<ProjectStaffMember> projectStaffMembers)
        {
            try
            {
                context.ProjectStaffMembers.AddRange(projectStaffMembers);
                var result = context.SaveChanges();

                return result>0;
            }
            catch (Exception ex)
            {
               return false;
            }

            
        }

        public List<ProjectStaffMemberViewModel> GetAll()
        {
            List<ProjectStaffMemberViewModel> projectStaffMembers = context.ProjectStaffMembers.Select(x => new ProjectStaffMemberViewModel() { }).ToList();

            return projectStaffMembers;
        }
    }
}
