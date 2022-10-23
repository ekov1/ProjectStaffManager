using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStaffManager.Models.Entities
{
    public class ProjectStaffMember : Entity
    {
        public int StaffMemberId { get; set; }
        public StaffMember StaffMember { get; set; }
        
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        

        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? DaysWorked { get; set; }
    }
}
