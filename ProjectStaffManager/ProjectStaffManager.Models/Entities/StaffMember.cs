using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStaffManager.Models.Entities
{
    public class StaffMember 
    {
        public int StaffMemberId { get; set; }
        public IList<ProjectStaffMember> ProjectStaffMembers { get; set; }
    }
}
