using System.ComponentModel.DataAnnotations;

namespace ProjectStaffManager.Models.Entities
{
    public class ProjectStaffMember 
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public int StaffMemberId { get; set; }
        public StaffMember StaffMember { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public int? DaysWorked { get; set; }
    }
}
