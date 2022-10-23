using Microsoft.EntityFrameworkCore;

namespace ProjectStaffManager.Models.Entities
{
    [Index(nameof(StaffMemberId), IsUnique = true)]
    public class StaffMember : Entity
    {
        public int StaffMemberId { get; set; }
        public IList<ProjectStaffMember> ProjectStaffMembers { get; set; }
    }
}
