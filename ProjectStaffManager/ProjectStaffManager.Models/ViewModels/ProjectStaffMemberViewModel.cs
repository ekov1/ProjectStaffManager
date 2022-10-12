
using ProjectStaffManager.Models.Entities;

namespace ProjectStaffManager.Models.ViewModels
{
    public class ProjectStaffMemberViewModel
    {
        public Project Project { get; set; }
        public StaffMember FirstStaffMember { get; set; }
        public StaffMember SecondStaffMember { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
    }
}
