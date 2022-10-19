using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectStaffManager.Models.Entities
{
    public class ProjectStaffMember : Entity
    {
        public int StaffMemberID { get; set; }
        public int ProjectID { get; set; }

       // [ForeignKey("StaffMemberID")]
        public StaffMember StaffMember { get; set; }
       // [ForeignKey("ProjectID")]
        public Project Project { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? DaysWorked { get; set; }
    }
}
