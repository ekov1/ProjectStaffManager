using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace ProjectStaffManager.Models.Entities
{
    //[Index(nameof(ProjectId), IsUnique = true)]
    public class Project :Entity
    {
        public int ProjectId { get; set; }
      //  public IList<ProjectStaffMember> ProjectStaffMembers { get; set; }
    }
}
