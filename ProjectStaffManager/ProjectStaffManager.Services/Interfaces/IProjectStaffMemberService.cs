using ProjectStaffManager.Models.Entities;
using ProjectStaffManager.Models.ViewModels;

namespace ProjectStaffManager.Services.Interfaces
{
    public interface IProjectStaffMemberService 
    {
        public List<ProjectStaffMemberViewModel> GetAll();
        public bool Create(IEnumerable<ProjectStaffMember> projectStaffMembers);

        }
}
