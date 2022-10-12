namespace ProjectStaffManager.Models.Entities
{
    public class Project 
    {
        public int ProjectId { get; set; }
        public IList<ProjectStaffMember> ProjectStaffMembers { get; set; }
    }
}
