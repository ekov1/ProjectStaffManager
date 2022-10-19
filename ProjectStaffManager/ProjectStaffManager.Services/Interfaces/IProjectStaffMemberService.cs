using ProjectStaffManager.Models.Entities;
using ProjectStaffManager.Models.ViewModels;

namespace ProjectStaffManager.Services.Interfaces
{
    public interface IProjectStaffMemberService 
    {
        public List<GridViewModel> GetAll();
        public Task<bool> Create(IEnumerable<ProjectStaffMember> projectStaffMembers);
        public List<GridViewModel> FindPairsEmployees(List<ProjectStaffMember> data);
        }
}
